using CycleQueue;
using IntegerSort;
using System;

namespace TestPL
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularQueue<int> intQueue = new CircularQueue<int>(1, 4, 100, 2, 5, 7, 5, 4, 56, 4, 6, 3, 7, 46, 46, 3);
            foreach (var a1 in intQueue)
            {
                Console.WriteLine(a1);
            }
            int[] a = new int[] { 1, 5, 7, 3, 5, 7, -42, 5, 7, 5, 4, 4, -80, 4, 3, 2, 1 };
            Sorting.Sort(a);
            foreach (var a1 in a)
            {
                Console.WriteLine(a1);
            }
            Sorting.Sort(a, new EvenBetterComparer().Compare);
            foreach (var a1 in a)
            {
                Console.WriteLine(a1);
            }
        }
    }
}
