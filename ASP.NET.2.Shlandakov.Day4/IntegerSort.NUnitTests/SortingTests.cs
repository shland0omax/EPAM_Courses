using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntegerSort.NUnitTests
{
    public class SortingTests
    {
        [TestCase(new [] { 7, 6, 5, 4, 1, -3, 2 }, Result = new[] {-3, 1, 2, 4, 5, 6, 7})]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        public int[] Sort_test(int[] array)
        {
            Sorting.Sort(array);
            return array;
        }
    }
}
