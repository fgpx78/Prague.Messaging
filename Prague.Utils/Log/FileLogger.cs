using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Utils
{
    public class FileLogger : ILogger
    {
        public FileLogger(string logName)
        {
            _logName = logName;
        }

        private string _logName;

        private string LogFile
        {
            get
            {
                if (!Directory.Exists(Configuration.LogFolder)) Directory.CreateDirectory(Configuration.LogFolder);
                string baseFile = Path.Combine(Configuration.LogFolder, "log.txt");
                //adds date to file name
                string filename = Path.GetFileNameWithoutExtension(baseFile) + DateTime.Today.ToString("yyyyMMdd") + "." + (string.IsNullOrEmpty(_logName) ? "" : _logName) + ".txt";
                return Path.Combine(Path.GetDirectoryName(baseFile), filename);
            }
        }

        public void Write(string message)
        {
            var logDate = DateTime.Now;
            TextWriter tw = new StreamWriter(LogFile, true);
            tw.WriteLine(logDate.ToString("s") + "\t" + message);
            tw.Close();
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
