using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Utils
{
    public interface ILogger
    {
        void Write(string message);
        void Write(string message, object lockObject);
    }
}
