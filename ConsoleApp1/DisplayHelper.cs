using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public static class DisplayHelper {
        public static void PrintNumberedList<T>(IList<T> list) {
            for (int i = 0; i < list.Count; i++) {
                Console.WriteLine($"{i+1}.\t{list[i]}");
            }
        }
        public static void PrintNumberedList<T>(IReadOnlyList<T> list) {
            for (int i = 0; i < list.Count; i++) {
                Console.WriteLine($"{i + 1}.\t{list[i]}");
            }
        }
    }
}
