using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {
    public interface IBlazeLogger:ILogger {
        void SetPrefix(string s);
    }
}
