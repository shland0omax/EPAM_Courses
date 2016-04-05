using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CycleQueue.NUnitTests
{
    public class CircularQueueTests
    {
        [TestCase(ExpectedException = typeof (ArgumentNullException))]
        public void Constructor_NullParam_test()
        {
            var temp = new CircularQueue<string>(null);
        }

        [TestCase(new [] {1,4,5,6}, Result = false)]
        [TestCase(new int[] {}, Result = true)]
        public bool IsEmpty_test(int[] a)
        {
            var temp = new CircularQueue<int>(a);
            return temp.IsEmpty();
        }

        [TestCase(new [] { 1, 4, 5, 6 }, Result = 1)]
        [TestCase(new int[] { }, ExpectedException = typeof(Exception))]
        public int Peek_test(int[] a)
        {
            var temp = new CircularQueue<int>(a);
            return temp.Peek();
        }

        [TestCase(new [] { 1, 4, 5, 6 }, 4, Result = 5)]
        [TestCase(new int[] { }, 4, Result = 1)]
        [TestCase(new [] { 1,45,6,3,5,3,6,3,6,3,6,3,6,3,5,3}, 4, Result = 17)]
        public int Enqueue_test(int[] a, int b)
        {
            var temp = new CircularQueue<int>(a);
            temp.Enqueue(b);
            return temp.QueueLength;
        }

        [TestCase(new [] { 1, 4, 5, 6 }, Result = 1)]
        [TestCase(new int[] { }, ExpectedException = typeof(Exception))]
        public int Dequeue_test(int[] a)
        {
            var temp = new CircularQueue<int>(a);
            return temp.Dequeue();
        }

        [TestCase(new [] { 12, -4, 4 , 3 }, 3,  Result = true)]
        [TestCase(new int[] { }, 4, Result = false)]
        [TestCase(new [] {4,6,7,3}, 2, Result = false)]
        public bool Contains_test(int[] a, int b)
        {
            var temp = new CircularQueue<int>(a);
            return temp.Contains(b);
        }

        [TestCase(new[] {12, -4, 4, 3}, Result = 0)]
        public int Clear_test(int[] a)
        {
            var temp = new CircularQueue<int>(a);
            temp.Clear();
            return temp.QueueLength;
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void GetEnumerator_Exception_test()
        {
            var q = new CircularQueue<string>("dsv", "sdbdb", null);
            var e = q.GetEnumerator();
            e.MoveNext();
            var s = e.Current;
            q.Clear();
            e.MoveNext();
            s = e.Current;
        }
    }
}
