using Prague.Messaging.Models;
using Prague.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Messaging
{
    public class SmtpServersManager
    {
        /// <summary>
        /// deserialize configuration file
        /// </summary>
        /// <returns></returns>
        public static SmtpServersConfiguration LoadSmtpServers()
        {
            var ssc2 = Serializer.Deserialize<SmtpServersConfiguration>(Configuration.SmtpServerConfigurationXmlFile);
            return ssc2;
        }

        /// <summary>
        /// serialize configuration file
        /// </summary>
        /// <param name="configurationToSave"></param>
        public static void SaveSmtpServers(SmtpServersConfiguration configurationToSave)
        {
            //try serialize and deserialize.
            Serializer.Serialize<SmtpServersConfiguration>(configurationToSave, Configuration.SmtpServerConfigurationXmlFile);
        }
    }
}
