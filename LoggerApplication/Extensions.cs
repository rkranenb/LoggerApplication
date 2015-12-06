using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApplication {
    static class Extensions {

        public static void Each<T>(this IEnumerable<T> items, Action<T> action) {
            foreach (var item in items) action(item);
        }
    }
}
