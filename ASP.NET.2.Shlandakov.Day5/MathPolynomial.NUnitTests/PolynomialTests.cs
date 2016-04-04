using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPolynomial;
using NUnit.Framework;

namespace MathPolynomial.NUnitTests
{
    public class PolynomialTests
    {
        [TestCase(new double[] { 3, 5, 2, -3, 2, 3}, Result = 5)]
        [TestCase(new double[] { 3, 5, 2}, Result = 2)]
        [TestCase(new double[] { 3, 5, 2, -3, 0, 0}, Result = 3)]
        public int DegreeProperty_test(double[] a)
        {
            var temp = new Polynomial(a);
            return temp.Degree;
        }

        [TestCase(new double[] {3, 4, 5}, new double[] {3, 4, 5}, Result = false)]
        [TestCase(null, new double[] {3, 4, 5}, Result = false)]
        [TestCase(null, null, Result = true)]
        public bool RefEqualityOperator_test(double[] a, double[] b)
        {
            Polynomial temp1, temp2;
            if (a == null) temp1 = null;
            else temp1 = new Polynomial(a);
            if (b == null) temp2 = null;
            else temp2 = new Polynomial(b);
            return temp2 == temp1;
        }

        [TestCase(new double[] { 3, 4, 5 }, 1, Result = 4)]
        [TestCase(new double[] { 3, 4, 5 }, 10, Result = 0)]
        [TestCase(new double[] { 3, 4, 5 }, -1, ExpectedException = typeof(IndexOutOfRangeException))]
        public double Indexator_test(double[] a, int index)
        {
            var temp = new Polynomial(a);
            return temp[index];
        }

        [TestCase(new double[] {3, 2, 1}, 2, Result = 11)]
        [TestCase(new double[] {3, 2, 1}, double.PositiveInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(new double[] {3, 2, 1}, double.NaN, ExpectedException = typeof(ArgumentException))]
        public double GetValue_test(double[] a, double value)
        {
            var temp = new Polynomial(a);
            return temp.GetValue(value);
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 3, 5, 2, -3, 2, 3 }, Result =  new double[] { 6, 7, 3, -3, 2, 3})]
        [TestCase(new double[] { 3, 2, 1 }, null, ExpectedException = typeof(ArgumentNullException))]
        public double[] Add_test(double[] a, double[] b)
        {
            Polynomial temp1 = new Polynomial(a), temp2;
            if (b == null) temp2 = null;
            else temp2 = new Polynomial(b);
            temp2 = Polynomial.Add(temp2, temp1);
            var res = new double[temp2.Degree+1];
            for (int i = 0; i < temp2.Degree+1; i++)
                res[i] = temp2[i];
            return res;
        }

        [TestCase(new double[] { 3, 2, 1 }, Result = new double[] { -3, -2, -1 })]
        [TestCase(null, ExpectedException = typeof(ArgumentNullException))]
        public double[] Negate_test(double[] a)
        {
            Polynomial temp1;
            if (a == null) temp1 = null;
            else temp1 = new Polynomial(a);
            temp1 = Polynomial.Negate(temp1);
            var res = new double[temp1.Degree + 1];
            for (int i = 0; i < temp1.Degree + 1; i++)
                res[i] = temp1[i];
            return res;
        }

        [TestCase(new double[] {-1, 1},  new double[] {1, 1}, Result = new double[] {-1, 0, 1})]
        [TestCase(new double[] {3, 2, 1}, null, ExpectedException = typeof (ArgumentNullException))]
        public double[] Multiply_test(double[] a, double[] b)
        {
            Polynomial temp1 = new Polynomial(a), temp2;
            if (b == null) temp2 = null;
            else temp2 = new Polynomial(b);
            temp2 = Polynomial.Multiply(temp2, temp1);
            var res = new double[temp2.Degree + 1];
            for (int i = 0; i < temp2.Degree + 1; i++)
                res[i] = temp2[i];
            return res;
        }
    }
}
