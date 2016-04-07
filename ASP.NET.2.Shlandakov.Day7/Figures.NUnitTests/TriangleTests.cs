using System;
using NUnit.Framework;

namespace Figures.NUnitTests
{
    public class TriangleTests
    {
        [TestCase(3,4,5, Result = 12)]
        public double GetPerimeter_test(double a, double b, double c)
        {
            var t = new Triangle(a,b,c);
            return t.GetPerimeter();
        }

        [TestCase(3,4,5, Result = 6)]
        public double GetArea_test(double a, double b, double c)
        {
            var t = new Triangle(a,b,c);
            return t.GetArea();
        }

        [TestCase(4, 4, 9, ExpectedException = typeof(ArgumentException))]
        [TestCase(double.NaN, 3,4 , ExpectedException = typeof(ArgumentException))]
        [TestCase(double.NegativeInfinity,5,5, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, 5, 4,  ExpectedException = typeof(ArgumentException))]
        [TestCase(3,4,5)]
        public void Constructor_test(double a, double b, double c)
        {
            var t = new Triangle(a,b,c);
        }

        [TestCase(3, 4, 5, Result = 12)]
        public double InterfaceCall_test(double a, double b, double c)
        {
            var t = new Triangle(a,b,c);
            IFigure t1 = t;
            return t1.GetPerimeter();
        }
    }
}