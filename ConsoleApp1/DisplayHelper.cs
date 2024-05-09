using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public static class DisplayHelper {
        public static void PrintNumberedList<T>(IList<T> list, int tabs = 0) {
            string tabString = "";
            for (int i = 0; i < tabs; i++) {
                tabString += "\t";
            }

            for (int i = 0; i < list.Count; i++) {
                Console.WriteLine($"{tabString}{i + 1}.\t{list[i]}");
            }
        }

        public static void PrintTribes(IList<ITribe> tribes) {
            for (int i = 0; i < tribes.Count; i++) {
                Console.WriteLine($"{i + 1}.\t{tribes[i]}");
                PrintNumberedList(tribes[i].Players, 1);
            }
        }
    }
}
