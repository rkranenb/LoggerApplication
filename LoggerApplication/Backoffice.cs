using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {

    public interface IBackoffice {
        void Execute();
    }

    public class Backoffice :IBackoffice{
        private IBackofficeLogger logger;
        private IService service;

        public Backoffice(IBackofficeLogger logger, IService service) {
            this.logger = logger;
            this.logger.SetPrefix("My");
            this.service = service;
        }

        public void Execute() {
            logger.Warn("I'm warning you...");
            service.Execute();
        }
    }
}
