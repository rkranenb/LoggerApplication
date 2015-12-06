using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Pipeline;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using NLog;

namespace LoggerApplication {

    public class LoggerConvention : IRegistrationConvention {

        public void ScanTypes(TypeSet types, Registry registry) {

            types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                .Where(type => type == typeof(Logger)).Each(type => {
                    // Register against all the interfaces implemented
                    // by this concrete class
                    type.GetInterfaces().Each(@interface => {
                        var name = GetLoggerNameFromInterface(@interface) ?? "Default";
                        var unique = new UniquePerRequestLifecycle();
                        registry.For(@interface)
                            .LifecycleIs(unique)                            
                            .Use(new Logger(LogManager.GetLogger(name)));
                    });
                });

        }

        private string GetLoggerNameFromInterface(Type @interface) {
            return @interface.Name.Replace("Logger", "").Substring(1);
        }
    }
}
