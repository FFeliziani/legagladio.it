using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Common
{
    public static class Configuration
    {
        private static LoggingConfiguration config = new LoggingConfiguration();

        private static FileTarget ft = new FileTarget();

        public static void init()
        {
            config.AddTarget("file", ft);

            ft.FileName("${basedir}/log.txt");
        }
    }
}
