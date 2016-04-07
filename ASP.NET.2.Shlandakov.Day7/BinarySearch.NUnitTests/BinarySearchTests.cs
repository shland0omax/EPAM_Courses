using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinarySearch.NUnitTests
{
    public class BinarySearchTests
    {
        private IEnumerable<TestCaseData> SearchTestData
        {
            get
            {
                yield return new TestCaseData(new [] {1,2,3,4,6,7,8,9}, 5).Returns(-1);
                yield return new TestCaseData(new [] {1,3,5,6,9,15,19,33,85,123}, 3).Returns(1);
                yield return new TestCaseData(new int[] {}, 1).Returns(-1);
                yield return new TestCaseData(new [] {"abc", "acb", "caab"}, "caab").Returns(2);
            }
        }

        [Test, TestCaseSource(nameof(SearchTestData))]
        public int BinarySearch_test<T>(T[] array, T key)
        {
            return Searcher.BinarySearch(array, key);
        }

        [TestCase(ExpectedException = typeof (ArgumentNullException))]
        public int BinarySearch_nullArray_test()
        {
            return Searcher.BinarySearch(null, 1);
        }

        [TestCase(Result = -1)]
        public int BinarySearch_nullKey_test()
        {
            return Searcher.BinarySearch(new[] { "abc", "acb", "caab" }, null);
        }

    }
}
