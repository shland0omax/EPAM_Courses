using System;
using MathPolynomial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathPolynomialTests
{
    [TestClass]
    public class PolynomialTests
    {
        private Polynomial testPolynomial = new Polynomial(3,5,2,-3,2,3);

        [TestMethod]
        public void DegreeProperty_testPolynomial_5Expected()
        {
            Assert.AreEqual(testPolynomial.Degree, 5);
        }

        [TestMethod]
        public void RefEqualityOperator_EqualDiffObjects_FalseExpected()
        {
            var a = new Polynomial(testPolynomial);
            Assert.AreEqual(testPolynomial == a, false);
        }

        [TestMethod]
        public void RefNotEqualityOperator_EqualSameObject_FalseExpected()
        {
            var a = testPolynomial;
            Assert.AreEqual(testPolynomial != a, false);
        }

        [TestMethod]
        public void Equals_EqualDiffObjects_TrueExpected()
        {
            var a = new Polynomial(testPolynomial);
            Assert.AreEqual(a.Equals( testPolynomial), true);
        }

        [TestMethod]
        public void EqualsStatic_EqualDiffObjects_TrueExpected()
        {
            var a = new Polynomial(testPolynomial);
            Assert.AreEqual(Polynomial.Equals(testPolynomial, a), true);
        }

        [TestMethod]
        public void EqualsStatic_Nulls_TrueExpected()
        {
            var a = new Polynomial();
            var b = new Polynomial();
            a = b = null;
            Assert.AreEqual(Polynomial.Equals(a, b), true);
        }

        [TestMethod]
        public void EqualsObject_EqualString_FalseExpected()
        {
            Assert.AreEqual(testPolynomial.Equals("sdvs"), false);
        }

        [TestMethod]
        public void Constructor_PolynomialIn()
        {
            var a = new Polynomial(testPolynomial);
            Assert.AreEqual(a, testPolynomial);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullPolynomialIn_ExpectedArgNullException()
        {
            var a = new Polynomial();
            a = null;
            var b = new Polynomial(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NaNPolynomialIn_ExpectedArgNullException()
        {
            var a = new Polynomial(4,6,double.NaN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InfPolynomialIn_ExpectedArgNullException()
        {
            var a = new Polynomial(4, 6, double.PositiveInfinity);
        }

        [TestMethod]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void Indexator_NegIndex_ExpIndexOutOfRangeExc()
        {
            var a = testPolynomial[-1];
        }

        [TestMethod]
        public void Indexator_testPolynomial3Index_Neg3Exp()
        {
            Assert.AreEqual(testPolynomial[3], -3);
        }

        [TestMethod]
        public void Indexator_testPolynomialFarIndex10_0Exp()
        {
            Assert.AreEqual(testPolynomial[10], 0);
        }

        [TestMethod]
        public void GetValue_testPolynomial1Value_12Expected()
        {
            Assert.AreEqual(testPolynomial.GetValue(1), 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValue_NaNValue_ExpectedArgExc()
        {
            Assert.AreEqual(testPolynomial.GetValue(double.NaN), 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValue_InfValue_ExpectedArgExc()
        {
            Assert.AreEqual(testPolynomial.GetValue(double.NegativeInfinity), 12);
        }

        [TestMethod]
        public void Add_testPolinomial_ExceptedDoubled()
        {
            Assert.AreEqual(Polynomial.Add(testPolynomial, testPolynomial), new Polynomial(6, 10, 4, -6, 4, 6));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_testPolinomialAndNull_ExpectedArgNullExc()
        {
            Assert.AreEqual(Polynomial.Add( testPolynomial, null), new Polynomial(6));
        }

        [TestMethod]
        public void Negate_testPolinomial_ExceptedNegated()
        {
            Assert.AreEqual(Polynomial.Negate(testPolynomial), new Polynomial(-3, -5, -2, 3, -2, -3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Negate_Null_ExpectedArgNullExc()
        {
            var a = new Polynomial(testPolynomial);
            a = null;
            Assert.AreEqual(Polynomial.Negate(a), new Polynomial(6));
        }

        [TestMethod]
        public void Multiply_testPolinomialAnd3_ExceptedTrippled()
        {
            var a = new Polynomial(3);
            Assert.AreEqual(Polynomial.Multiply(testPolynomial, 3), new Polynomial(9, 15, 6, -9, 6, 9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Multiply_NullAndTestPolynomial_ExpectedArgNullExc()
        {
            Assert.AreEqual(Polynomial.Multiply(null, testPolynomial), new Polynomial(6));
        }

        [TestMethod]
        public void PlusOperator_testPoly_ExpectedDoubled()
        {
            Assert.AreEqual(testPolynomial + testPolynomial, new Polynomial(6, 10, 4, -6, 4, 6));
        }

        [TestMethod]
        public void MinusOperator_testPoly_0Expected()
        {
            Assert.AreEqual(testPolynomial - testPolynomial, new Polynomial());
        }

        [TestMethod]
        public void NegateOperator_testPoly_ExpectedNegated()
        {
            Assert.AreEqual(- testPolynomial, new Polynomial(-3, -5, -2, 3, -2, -3));
        }

        [TestMethod]
        public void MultiOperator_testPoly_ExpectedTrippled()
        {
            var a = new Polynomial(3);
            Assert.AreEqual(testPolynomial * a, new Polynomial(9, 15, 6, -9, 6, 9));
        }

        [TestMethod]
        public void ToString_test()
        {
            var s = "+3x^5+2x^4-3x^3+2x^2+5x^1+3";
            Assert.AreEqual(s, testPolynomial.ToString());
        }
    }
}
