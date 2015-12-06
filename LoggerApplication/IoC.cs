using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {

    static class IoC {

        public static IContainer Initialize() {
            return new Container(registry => {
                registry.Scan(scan => {
                    scan.WithDefaultConventions();
                    scan.TheCallingAssembly();
                    scan.Convention<LoggerConvention>();
                });
            });
        }

    }
}
