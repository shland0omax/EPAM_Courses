using System;
using EuclideanAlgoLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuclideanAlgoLLTests
{
    [TestClass]
    public class GcdCalculatorTests
    {
        [TestMethod]
        public void GcdEuclidean_5and13_1Expected()
        {
            Assert.AreEqual(GcdCalculator.GcdEuclidean(5,13), 1);
        }

        [TestMethod]
        public void GcdEuclidean_3and9andNeg27_3Expected()
        {
            Assert.AreEqual(GcdCalculator.GcdEuclidean(3,9,-27), 3);
        }

        [TestMethod]
        public void GcdEuclidean_Time_InitExpected()
        {
            long a;
            GcdCalculator.GcdEuclidean(out a, 3, 9, -27);
            Assert.AreNotEqual(a, 0);
        }

        [TestMethod]
        public void GcdEuclidean_49andNeg14_7Expected()
        {
            long a;
            Assert.AreEqual(GcdCalculator.GcdEuclidean( 49, 14, out a), 7);
        }

        [TestMethod]
        public void GcdBinary_144and15_3Expected()
        {
            Assert.AreEqual(GcdCalculator.GcdBinary(144, 15), 3);
        }

        [TestMethod]
        public void GcdBinary_49and14and56_7Expected()
        {
            Assert.AreEqual(GcdCalculator.GcdBinary(49, 14, 56), 7);
        }

        [TestMethod]
        public void GcdBinary_Time_InitExpected()
        {
            long a;
            GcdCalculator.GcdBinary(out a, 49, 14, 56);
            Assert.AreNotEqual(a, 0);
        }

        [TestMethod]
        public void GcdBinary_1024andNeg128_128Expected()
        {
            long a;
            Assert.AreEqual(GcdCalculator.GcdBinary(1024, -128, out a), 128);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void GcdEuclidean_NoArgs_ExpectedArgException()
        {
            GcdCalculator.GcdEuclidean();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GcdBinary_NoArgs_ExpectedArgException()
        {
            GcdCalculator.GcdBinary();
        }

        [TestMethod]
        public void GcdEuclidean_1Arg_AbsArgExpected()
        {
            Assert.AreEqual(GcdCalculator.GcdEuclidean(-2), 2);
        }

        [TestMethod]
        public void GcdBinary_1Arg_AbsArgExpected()
        {
            Assert.AreEqual(GcdCalculator.GcdBinary(-2), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GcdEuclidean_NullArgs_ExpectedArgNullException()
        {
            GcdCalculator.GcdEuclidean(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GcdBinary_NullArgs_ExpectedArgNullException()
        {
            GcdCalculator.GcdBinary(null);
        }
    }
}
