using CycleQueue;
using IntegerSort;
using System;

namespace TestPL
{
    enum SomeEnum: byte
    {
        some1, some2
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularQueue<int> intQueue = new CircularQueue<int>(1, 4, 100, 2, 5, 7, 5, 4, 56, 4, 6, 3, 7, 46, 46, 3);
            foreach(var a in intQueue)
            {
                Console.WriteLine(a);
            }
        }
    }
}
