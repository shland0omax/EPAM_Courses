using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NewtonLL.NUnitTests
{
    public class NewtonMethodTests
    {
        private IEnumerable<TestCaseData> NewtonMethodTestCase
        {
            get
            {
                yield return new TestCaseData(4, 2, double.Epsilon).Returns(2);
                yield return new TestCaseData(-27, 3, double.Epsilon).Returns(-3);
                yield return new TestCaseData(-49, 2, 1).Returns(double.NaN);
                yield return new TestCaseData(double.NaN, 3, double.Epsilon).Throws(typeof(ArgumentException));
                yield return new TestCaseData(100, -1, double.NaN).Throws(typeof(ArgumentException));
                yield return new TestCaseData(4, -2, double.Epsilon).Returns(0.5);
                yield return new TestCaseData(100, -1, -1).Throws(typeof(ArgumentException));
            }
        }

        [Test, TestCaseSource(nameof(NewtonMethodTestCase))]
        public double Execute_test(double a, int exponent, double eps)
        {
            return NewtonMethod.Execute(a, exponent, eps);
        }
    }
}
