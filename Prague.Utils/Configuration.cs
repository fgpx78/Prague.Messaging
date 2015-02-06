using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Utils
{
    public class Configuration : Prague.Base.ConfigurationBase<Configuration>
    {
        public static string LogFolder { get; set; }
    }
}
