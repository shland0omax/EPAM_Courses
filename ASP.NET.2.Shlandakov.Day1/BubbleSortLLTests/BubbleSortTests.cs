using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BubbleSortLL;

namespace BubbleSortLLTests
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void SortJaggedRows_NonEmptyRowsBySumAscending()
        {
            var a = new[]
            {
                new[] {1, 5, 7, 4, 7},
                new[] {0, 1}
            };
            var b = new[] {a[1], a[0]};
            BubbleSort.SortJaggedRows(a, TaskComparer.SumRowCompare);
            CollectionAssert.AreEqual(a, b); 
        }

        [TestMethod]
        public void SortJaggedRows_NonEmptyRowsByMaxDescending()
        {
            var a = new[]
            {
                new[] {1, 5, 7, 4, 7, 12, 3},
                new[] {25, 4, 5, 6, -3},
                new[] {0, 1, 13}
            };
            var b = new[] { a[1], a[2], a[0] };
            BubbleSort.SortJaggedRowsByDesc(a, TaskComparer.MaxElementCompare);
            CollectionAssert.AreEqual(a, b);
        }

        [TestMethod]
        public void SortJaggedRows_EmptyRowByMinAscending()
        {
            var a = new[]
            {
                new[] {1, 5, 7, 4, 7, -12, 3},
                new int[] {}
            };
            var b = new[] { a[1], a[0] };
            BubbleSort.SortJaggedRows(a, new MinElementComparer());
            CollectionAssert.AreEqual(a, b);
        }

        [TestMethod]
        public void SortJaggedRows_NullRowsByMinDescending()
        {
            var a = new[]
            {
                new[] {1, 5, 7, 4, 7, -12, 3},
                null
            };
            var b = new[] { a[1], a[0] };
            BubbleSort.SortJaggedRows(a, new MinElementComparer());
            CollectionAssert.AreEqual(a, b);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SortJaggedRows_NullArray_ExpectedException()
        {
            BubbleSort.SortJaggedRows(null, TaskComparer.MaxElementCompare);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SortJaggedRows_NullComparer_ExpectedException()
        {
            var a = new int[2][];
            var c = new MinElementComparer();
            c = null;
            BubbleSort.SortJaggedRows(a, c);
        }
    }
}
