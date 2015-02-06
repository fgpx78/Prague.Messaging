using Prague.Messaging.Models;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Net.Mail;
using System.Net.Mime;
using Prague.Utils;

namespace Prague.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    public class Mailer
    {

        /// <summary>
        /// Send a single email
        /// </summary>
        /// <param name="email">email To address</param>
        /// <param name="subject">subject</param>
        /// <param name="body">body text</param>
        /// <param name="smtpServer"></param>
        /// <param name="logName"></param>
        /// <returns></returns>
        public bool Send(string email, string subject, string body, SmtpServer smtpServer, string logName)
        {
            //http://www.intstrings.com/ramivemula/articles/how-to-send-an-email-using-c-net-with-complete-features/

            string logText = String.Empty;
            bool result = false;
            if(string.IsNullOrEmpty(body) || string.IsNullOrEmpty(subject))
            {
                logText = String.Format("Error sending mail to {0}. Exception: subject or body is empty", email);
            }
            else
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(smtpServer.MailFrom);
                    msg.To.Add(new MailAddress(email));
                    if (!string.IsNullOrEmpty(smtpServer.MailCC)) msg.CC.Add(new MailAddress(smtpServer.MailCC));
                    if (!string.IsNullOrEmpty(smtpServer.MailBCC)) msg.Bcc.Add(new MailAddress(smtpServer.MailBCC));

                    msg.Subject = subject;
                    msg.Body = body;
                    msg.IsBodyHtml = true;

                    smtpServer.SmtpClient.Send(msg);
                    logText = String.Format("{0} sent. Subject {1} on server {2}", email, subject, smtpServer.Address);
                    System.Threading.Thread.Sleep(smtpServer.SendIntervalSeconds * 1000); //1 seconds. to delay t 1 minut after tests. minut
                    result = true;
                }
                catch (Exception exx)
                {
                    logText = String.Format("Error sending mail to {0}. Exception: {1}", email, exx.Message + " " + exx.StackTrace);
                }
            }
            new FileLogger(logName).Write(logText);
            return result;
        }
    }
}
