using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {

    public interface IService {

        void Execute();

    }

    public class Service : IService {

        private IServiceLogger logger;

        public Service(IServiceLogger logger) {
            this.logger = logger;
            this.logger.SetPrefix("Foo");
        }

        public void Execute() {
            logger.Info("Doing something.");
        }

    }
}
