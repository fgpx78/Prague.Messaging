using Prague.Messaging;
using Prague.Messaging.Models;
using Prague.Utils;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTester
{
    class Program
    {
        //parameters to be set in the user interface ;)
        private static string RecipientsXlsFilePath = @"c:\temp\recipients2.xlsx";
        

        static void Main(string[] args)
        {
            SmtpServersConfiguration smtpConfiguration = SmtpServersManager.LoadSmtpServers(); //load all smtp servers
            List<ExpandoObject> recipients = RecipientsManager.LoadRecipients(); //load all recipients
            Dictionary<string, Template> templates = TemplateManager.LoadTemplates(); //load all templates

            //control if any template missing?
            //checktemplates(templates,recipient)

            //start mailing
            var mailer = new Prague.Messaging.BatchMailer();
            mailer.SendBulkMails(recipients, templates, smtpConfiguration);
        }

    }


}
