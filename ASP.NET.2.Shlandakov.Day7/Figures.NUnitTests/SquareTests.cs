using System;
using NUnit.Framework;

namespace Figures.NUnitTests
{
    public class SquareTests
    {
        [TestCase(2, Result = 8)]
        public double GetPerimeter_test(double side)
        {
            var a = new Square(side);
            return a.GetPerimeter();
        }

        [TestCase(2, Result = 4)]
        public double GetArea_test(double side)
        {
            var a = new Square(side);
            return a.GetArea();
        }

        [TestCase(4)]
        [TestCase(double.NaN, ExpectedException = typeof(ArgumentException))]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentException))]
        public void Constructor_test(double side)
        {
            var a = new Square(side);
        }

        [TestCase(2, Result = 4)]
        public double BaseClassCall_test(double side)
        {
            var a = new Square(side);
            Rectangle t = a;
            return t.GetArea();
        }

        [TestCase(2, Result = 8)]
        public double InterfaceCall_test(double side)
        {
            var a = new Square(side);
            IFigure t = a;
            return t.GetPerimeter();
        }
    }
}