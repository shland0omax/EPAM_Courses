using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EuclideanAlgoLL.NUnitTests
{
    public class GcdCalculatorTests
    {
        private IEnumerable<TestCaseData> PairTestData
        {
            get
            {
                yield return new TestCaseData(5, 13).Returns(1);
                yield return new TestCaseData(-4,16).Returns(4);
                yield return new TestCaseData(0, 13).Returns(13);
            }
        }

        private IEnumerable<TestCaseData>  ParamsTestData
        {
            get
            {
                yield return new TestCaseData(new[] { 0, 4, 8, 16}).Returns(4);
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new int[] {}).Throws(typeof(ArgumentException));
                yield return new TestCaseData(new [] { -33}).Returns(33);
            }
        }

        [Test, TestCaseSource(nameof(PairTestData))]
        public int GcdEuclidean_test(int a, int b)
        {
            return GcdCalculator.GcdEuclidean(a, b);
        }

        [Test, TestCaseSource(nameof(ParamsTestData))]
        public int GcdEuclidean_test(int[] args)
        {
            return GcdCalculator.GcdEuclidean(args);
        }

        [TestCase(new[] {1,4,56,23,64,4}, Result = true)]
        public bool GcdEuclidean_ticsCheck_test(int[] args)
        {
            long a, b;
            GcdCalculator.GcdEuclidean(out a, args);
            GcdCalculator.GcdEuclidean(args[0], args[1], out b);
            return (a > 0) && (b > 0);
        }

        [Test, TestCaseSource(nameof(PairTestData))]
        public int GcdBinary_test(int a, int b)
        {
            return GcdCalculator.GcdBinary(a, b);
        }

        [Test, TestCaseSource(nameof(ParamsTestData))]
        public int GcdBinary_test(int[] args)
        {
            return GcdCalculator.GcdBinary(args);
        }

        [TestCase(new[] { 1, 4, 56, 23, 64, 4 }, Result = true)]
        public bool GcdBinary_ticsCheck_test(int[] args)
        {
            long a, b;
            GcdCalculator.GcdBinary(out a, args);
            GcdCalculator.GcdBinary(args[0], args[1], out b);
            return (a > 0) && (b > 0);
        }
    }
}
