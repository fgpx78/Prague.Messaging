using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prague.Messaging.Models
{
    [XmlRoot("root")]
    public class SmtpServersConfiguration
    {
        private List<SmtpServer> _smtpServers;

        [XmlArrayItem("SmtpServer", typeof(SmtpServer))]
        [XmlArray("SmtpServers")]
        public List<SmtpServer> SmtpServers
        {
            get { return _smtpServers; }
            set { _smtpServers = value; }
        }
    }

    
}
