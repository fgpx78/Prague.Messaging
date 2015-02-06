using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Messaging.Models
{
    public class Template
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        /// <summary>
        /// Create body from template and data
        /// </summary>
        /// <param name="data"></param>
        public  string BodyParsed(dynamic data)
        {
            string body = Razor.Parse(this.Body, data);
            return body;
        }

        /// <summary>
        /// Create subject text from template and data
        /// </summary>
        /// <param name="data"></param>
        public string SubjectParsed(dynamic data)
        {
            string sbj = Razor.Parse(this.Subject, data);
            return sbj;
        }
    }
}
