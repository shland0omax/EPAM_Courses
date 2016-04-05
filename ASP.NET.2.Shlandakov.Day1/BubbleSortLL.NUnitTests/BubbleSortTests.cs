using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BubbleSortLL.NUnitTests
{
    public class BubbleSortTests
    {
        private int[][] a = {new[] {12, 4, 5}, new[] {5, 1, 7}, new []{-3, 5, 23}};

        private IEnumerable<TestCaseData> IComparerTestCase
        {
            get
            {
                yield return new TestCaseData(a, new MinElementComparer()).Returns(new[] {a[2], a[1], a[0]});
                yield return new TestCaseData(null, new MinElementComparer()).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(a, null).Throws(typeof(ArgumentNullException));
            }
        }

        [Test, TestCaseSource(nameof(IComparerTestCase))]
        public static int[][] SortJaggedRows_IComparer_test(int[][] array, IComparer<int[]> comparer)
        {
            BubbleSort.SortJaggedRows(array, comparer);
            return array;
        }

        private IEnumerable<TestCaseData> MaxElemTestCase
        {
            get
            {
                yield return new TestCaseData(a, true).Returns(new [] { a[1], a[0], a[2] });
                yield return new TestCaseData(null, false).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(a, false).Returns(new[] {a[2], a[0], a[1]});
            }
        }

        [Test, TestCaseSource(nameof(MaxElemTestCase))]
        public static int[][] SortJaggedRows_ComparisionMaxElem_test(int[][] array, bool byAsc = true)
        {
            if (byAsc)
                BubbleSort.SortJaggedRows(array, TaskComparer.MaxElementCompare);
            else
                BubbleSort.SortJaggedRowsByDesc(array, TaskComparer.MaxElementCompare);
            return array;
        }

        private IEnumerable<TestCaseData> SumElemsTestCase
        {
            get
            {
                yield return new TestCaseData(a, true).Returns(new[] { a[1], a[0], a[2] });
                yield return new TestCaseData(null, true).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(a, false).Returns(new[] {a[2], a[0], a[1]});
            }
        }

        [Test, TestCaseSource(nameof(SumElemsTestCase))]
        public static int[][] SortJaggedRows_ComparisionSumElems_test(int[][] array, bool byAsc = true)
        {
            if (byAsc)
                BubbleSort.SortJaggedRows(array, TaskComparer.SumRowCompare);
            else
                BubbleSort.SortJaggedRowsByDesc(array, TaskComparer.SumRowCompare);
            return array;
        }

        private IEnumerable<TestCaseData> MinElemTestCase
        {
            get
            {
                yield return new TestCaseData(a, true).Returns(new[] { a[2], a[1], a[0] });
                yield return new TestCaseData(null, true).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(a, false).Returns(new[] { a[0], a[1], a[2] });
            }
        }

        [Test, TestCaseSource(nameof(MinElemTestCase))]
        public static int[][] SortJaggedRows_ComparisionMinElems_test(int[][] array, bool byAsc = true)
        {
            if (byAsc)
                BubbleSort.SortJaggedRows(array, TaskComparer.MinElementCompare);
            else
                BubbleSort.SortJaggedRowsByDesc(array, TaskComparer.MinElementCompare);
            return array;
        }
    }
}
