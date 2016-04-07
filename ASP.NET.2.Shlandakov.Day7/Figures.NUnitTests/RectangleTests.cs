using System;
using NUnit.Framework;

namespace Figures.NUnitTests
{
    public class RectangleTests
    {
        [TestCase(4,6, Result = 20)]
        public double GetPerimeter_test(double a, double b)
        {
            var r = new Rectangle(a,b);
            return r.GetPerimeter();
        }

        [TestCase(3,5, Result = 15)]
        public double GetArea_test(double a, double b)
        {
            var r = new Rectangle(a,b);
            return r.GetArea();
        }

        [TestCase(4,1)]
        [TestCase(double.NaN, 1,  ExpectedException = typeof(ArgumentException))]
        [TestCase(double.NegativeInfinity, 3, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, 3, ExpectedException = typeof(ArgumentException))]
        public void Constructor_test(double a, double b)
        {
            var r = new Rectangle(a,b);
        }

        [TestCase(2, 4, Result = 8)]
        public double InterfaceCall_test(double a, double b)
        {
            var r = new Rectangle(a,b);
            IFigure t = r;
            return t.GetArea();
        }
    }
}