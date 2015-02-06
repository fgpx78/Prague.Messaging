using Prague.Messaging.Models;
using Prague.Utils;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Messaging
{
    public class BatchMailer
    {
        public bool Canceled { get; private set; }
        public bool HasError { get; private set; }

        public BatchMailer()
        {
            HasError = false;
            Canceled = false;
        }

        /// <summary>
        /// Send bulk emails to recipients
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="razorTemplate"></param>
        /// <param name="SMTPConfiguration"></param>
        public void SendBulkMails(List<ExpandoObject> recipients, Dictionary<string, Template> templates, SmtpServersConfiguration smtpConfiguration)
        {
            string logName = "BATCH";
            Prague.Utils.FileLogger generalLogger = new Prague.Utils.FileLogger(logName);
            
            var dynRec = recipients.Cast<dynamic>();

            List<Task<bool>> tasks = new List<Task<bool>>();
            //group recipients by domain (to prevent spam as far as possible)
            foreach (var rcpGrp in dynRec.GroupBy(x => x.Email.Substring(x.Email.IndexOf('@') + 1)))
            {
                for (int i = 0; i < smtpConfiguration.SmtpServers.Count(); i++) //cycles the available servers
                {
                    var smtpServer = smtpConfiguration.SmtpServers[i];
                    int grpCount = (int)Math.Ceiling((decimal)rcpGrp.Count() / (decimal)smtpConfiguration.SmtpServers.Count); //divide the emails to send per each availavble smtp server

                    //temp var so they'll not be modified by other thread
                    var passGrpCount = grpCount;
                    var passCounter = i;

                    //start task foreach SERVER
                    var t = Task<bool>.Run(() =>
                    {
                        bool result = true;
                        generalLogger.Write(String.Format("Batch mail sending task number {0} running on SmtpServer {1} for domain {2}", Task.CurrentId.ToString(), smtpServer.Address, rcpGrp), smtpConfiguration); //locked by smtpConfiguration, ncessary for logging GENERAL, that is shared by processes.
                        foreach (var r in rcpGrp.Skip(passCounter * passGrpCount).Take(passGrpCount)) //elaborate only email for the selected server
                        {
                            if (Canceled) break;
                            string body = "";
                            string subject = "";
                            string taskLoggerName = Task.CurrentId.ToString();
                            //prepare templates and send email
                            try
                            {
                                body = templates[r.Template].BodyParsed(r);
                                subject = templates[r.Template].SubjectParsed(r);
                            }
                            catch(Exception ex)
                            {
                                new FileLogger(taskLoggerName).Write(String.Format("Error sending mail to {0}. Exception: {1}", r.Email, ex.Message + " " + ex.StackTrace));
                                result = false;
                                continue;
                            }
                            Mailer mailer = new Mailer();
                            if (!mailer.Send(r.Email, subject, body, smtpServer, taskLoggerName))
                                result = false;
                        }
                        return result;
                    }
                    );
                    tasks.Add(t);
                    //end task FOREACH SERVER
                }
            }
            Task.WaitAll(tasks.ToArray());
            foreach(var task in tasks)
            {
                if (!task.Result)
                {
                    HasError = true;
                    break;
                }
            }
        }

        public void Cancel()
        {
            Canceled = true;
        }
    }
}
