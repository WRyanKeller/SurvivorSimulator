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

        public static List<T>[] SplitIntoLists<T>(ref List<T> list, int num = 2) {
            _ = ScrambleList(ref list);
            List<T>[] lists = new List<T>[num];

            List<List<T>> listsLeft = new List<List<T>>();
            int lockedIn = 0;
            double milestone = (list.Count + .1) / (double)num;
            double nextMilestone = milestone;
            
            // prepare our new lists
            for (int i = 0; i < num; i++) {
                lists[i] = new List<T>();
                listsLeft.Add(lists[i]);
            }

            foreach (T item in list) {
                // add item to random list remaining
                int index = GetRandomInt(listsLeft.Count);

                // if this tribe is large enough
                while (lockedIn + listsLeft[index].Count > nextMilestone - 1) {
                    // take it out of the mix
                    lockedIn += listsLeft[index].Count;
                    nextMilestone += milestone;
                    listsLeft.RemoveAt(index);
                    index = GetRandomInt(listsLeft.Count);
                }

                listsLeft[index].Add(item);
            }

            return lists;
        }

        public static List<T> ScrambleList<T>(ref List<T> list) {
            List<T> newList = new List<T>();

            for (int i = list.Count; i > 0; i--) {
                int index = GetRandomInt(i);
                newList.Add(list[index]);
                list.RemoveAt(index);
            }

            list = newList;
            return list;
        }
    }
}
