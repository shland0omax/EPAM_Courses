using System;
using IntegerSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegerSortTests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void Sort_NonEmptyArray()
        {
            var a = new int[] {7, 6, 5, 4, 1, -3, 2};
            var b = new int[] {-3, 1, 2, 4, 5, 6, 7};
            Sorting.Sort(a);
            CollectionAssert.AreEqual(a, b);
        }

        [TestMethod]
        public void Sort_ArrayWithIComparerObject()
        {
            var a = new int[] { 7, 6, 5, 4, 1, -3, 2 };
            var b = new int[] { -3, 1, 5, 7, 2, 4, 6 };
            Sorting.Sort(a, new EvenBetterComparer());
        }

        [TestMethod]
        public void Sort_ArrayWithComparisionDelegate()
        {
            var a = new int[] { 7, 6, 5, 4, 1, -3, 2 };
            var b = new int[] { -3, 1, 5, 7, 2, 4, 6 };
            var comp = new EvenBetterComparer();
            Sorting.Sort(a, comp.Compare);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray_ExpectedException()
        {
            Sorting.Sort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullIComparer_ExpectedException()
        {
            var a = new int[] { 7, 6, 5, 4, 1, -3, 2 };
            var c = new DefaultIntComparer();
            c = null;
            Sorting.Sort(a, c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullComparision_ExpectedException()
        {
            var a = new int[] { 7, 6, 5, 4, 1, -3, 2 };
            Comparison<int> c = (x, y) => x > y ? 1 : x < y ? -1 : 0;
            c = null;
            Sorting.Sort(a, c);
        }
    }
}
