using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {

    public interface ILogger {
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
    }

    public class Logger : IServiceLogger, IBackofficeLogger {

        private readonly NLog.Logger logger;
        private string prefix;

        public Logger(NLog.Logger logger) {
            this.logger = logger;
        }

        public void Info(string message, params object[] args) {
            Log(NLog.LogLevel.Info, message, args);
        }

        public void Warn(string message, params object[] args) {
            Log(NLog.LogLevel.Warn, message, args);
        }

        private void Log(NLog.LogLevel level, string message, params object[] args) {
            string name = string.Format("{0}{1}", prefix, logger.Name);
            var logEvent = new NLog.LogEventInfo(level, name, CultureInfo.InvariantCulture, message, args);
            logger.Log(logEvent);
        }

        public void SetPrefix(string s) {
            prefix = s;
        }
    }
}
