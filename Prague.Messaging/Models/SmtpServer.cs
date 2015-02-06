using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prague.Messaging.Models
{
    public class SmtpServer
    {
        [XmlAttribute("Address")]
        public string Address { get; set; }
        [XmlAttribute("Port")]
        public int Port { get; set; }
        [XmlAttribute("Username")]
        public string Username { get; set; }
        [XmlAttribute("Password")]
        public string Password { get; set; }
        [XmlAttribute("EnableSsl")]
        public bool EnableSsl { get; set; }
        [XmlAttribute("MailFrom")]
        public string MailFrom { get; set; }
        [XmlAttribute("MailCC")]
        public string MailCC { get; set; }
        [XmlAttribute("MailBCC")]
        public string MailBCC { get; set; }
        [XmlAttribute("SendIntervalSeconds")]
        public int SendIntervalSeconds { get; set; }


        [XmlIgnoreAttribute]
        public SmtpClient SmtpClient
        {
            get
            {
                SmtpClient _smtpClient = new SmtpClient(); //cna't share, otherwise not thred safe
                _smtpClient.Host = this.Address;
                _smtpClient.Port = this.Port;
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtpClient.EnableSsl = this.EnableSsl; // runtime encrypt the SMTP communications using SSL                
                if (this.EnableSsl) _smtpClient.Credentials = new System.Net.NetworkCredential(this.Username, this.Password);
                return _smtpClient;
            }
        }
    }
}
