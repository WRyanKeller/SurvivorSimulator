using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StaticRng {
        private static Random rng;

        static StaticRng() {
            rng = new Random();
        }

        public static int GetRandomInt(int max) {
            return rng.Next(max);
        }

        public static int GetRandomInt(int min, int max) {
            return rng.Next(min, max);
        }

        public static T RandomFromList<T>(List<T> list) {
            return list[GetRandomInt(list.Count)];
        }
    }
}
