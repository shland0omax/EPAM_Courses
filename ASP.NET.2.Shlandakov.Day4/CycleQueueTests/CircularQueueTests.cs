using System;
using CycleQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleQueueTests
{
    [TestClass]
    public class CircularQueueTests
    {
        private readonly CircularQueue<int> NonEmptyQueue = new CircularQueue<int>(1, 45, 7, 4, 3);
        private readonly CircularQueue<int> EmptyQueue = new CircularQueue<int>();

        [TestMethod]
        public void IsEmpty_NonEmpty_FalseExpected()
        {
            Assert.AreEqual(NonEmptyQueue.IsEmpty(), false);
        }

        [TestMethod]
        public void IsEmpty_Empty_TrueExpected()
        {
            Assert.AreEqual(EmptyQueue.IsEmpty(), true);
        }

        [TestMethod]
        public void Enqueue_EmptyQueue_Length1Expected()
        {
            CircularQueue<int> q = new CircularQueue<int>();
            q.Enqueue(35);
            Assert.AreEqual(q.QueueLength, 1);
        }

        [TestMethod]
        public void Peek_NonEmptyQueue_1Expected()
        {
            Assert.AreEqual(NonEmptyQueue.Peek(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Peek_EmptyQueue_ExpectedException()
        {
            EmptyQueue.Peek();
        }

        [TestMethod]
        public void Enqueue_EmptyQueueAnd35_35PeekExpected()
        {
            CircularQueue<int> q = new CircularQueue<int>();
            q.Enqueue(35);
            var a = q.Peek();
            Assert.AreEqual(a, 35);
        }

        [TestMethod]
        public void Dequeue_NonEmptyQueue_1Expected()
        {
            var a = NonEmptyQueue.Dequeue();
            Assert.AreEqual(a, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Dequeue_EmptyQueue_ExpectedException()
        {
            EmptyQueue.Dequeue();
        }

        [TestMethod]
        public void Contains_NonEmptyQueueAnd7_TrueExpected()
        {
            Assert.AreEqual(NonEmptyQueue.Contains(7), true);
        }

        [TestMethod]
        public void Contains_EmptyQueueAnd7_FalseExpected()
        {
            Assert.AreEqual(EmptyQueue.Contains(6), false);
        }

        [TestMethod]
        public void Contains_StringWithNullQueueAndNull_TrueExpected()
        {
            var q = new CircularQueue<string>("dsv", "sdbdb", null);
            Assert.AreEqual(q.Contains(null), true);
        }

        [TestMethod]
        public void Clear_NonEmptyQueue_Length0Expected()
        {
            var q = new CircularQueue<string>("dsv", "sdbdb", null);
            q.Clear();
            Assert.AreEqual(q.QueueLength, 0);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void GetEnumerator_ClearedQueue_ExpectedInvalidOperationException()
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
