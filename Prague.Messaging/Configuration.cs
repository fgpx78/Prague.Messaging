using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Messaging
{
    public class Configuration : Prague.Base.ConfigurationBase<Configuration>
    {
        /// <summary>
        /// Folder contained templates
        /// </summary>
        public static string TemplatesFolder { get; set; }

        /// <summary>
        /// File with SMTP configuration
        /// </summary>
        public static string SmtpServerConfigurationXmlFile { get; set; }

        /// <summary>
        /// File with recipients
        /// </summary>
        public static string RecipientListFile { get; set; }
    }
}
