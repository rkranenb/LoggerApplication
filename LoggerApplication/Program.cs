using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {

    class Program {

        static void Main(string[] args) {
            try {
                var container = IoC.Initialize();
                container.GetInstance<IBackoffice>().Execute();
            } catch (Exception e) {
                while (e != null) {
                    Console.WriteLine(e.Message);
                    e = e.InnerException;
                }
            }
        }
    }
}
