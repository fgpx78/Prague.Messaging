using Prague.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpsi.Utils.Log
{
    class UXLogger : ILogger
    {
        public class WrittenMessageEventArgs
        {
            public DateTime Date { get; set; }
            public string LogName { get; set; }
            public string Message { get; set; }
        }
        public delegate void WrittenMessageEventHandler(object sender, WrittenMessageEventArgs e);
        public event WrittenMessageEventHandler MessageHasBeenWritten;

        private string _logName;
        public UXLogger(string logName)
        {
            _logName = logName;
        }

        public void Write(string message)
        {
            MessageHasBeenWritten(this, new WrittenMessageEventArgs() { Date = DateTime.Now, LogName = _logName, Message = message });
        }

        public void Write(string message, object lockObject)
        {
            lock (lockObject)
            {
                Write(message);
            }
        }
    }
}
