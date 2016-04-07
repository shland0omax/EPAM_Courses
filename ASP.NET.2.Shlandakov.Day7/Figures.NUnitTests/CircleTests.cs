using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Figures.NUnitTests
{
    public class CircleTests
    {
        [TestCase(Result = 2*Math.PI)]
        public double GetPerimeter_test()
        {
            var a = new Circle(1);
            return a.GetPerimeter();
        }

        [TestCase( 2, Result = Math.PI*4)]
        public double GetArea_test(double rad)
        {
            var a = new Circle(rad);
            return a.GetArea();
        }

        [TestCase(4)]
        [TestCase(double.NaN, ExpectedException = typeof (ArgumentException))]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof (ArgumentException))]
        [TestCase(-1, ExpectedException = typeof (ArgumentException))]
        public void Constructor_test(double radius)
        {
            var a = new Circle(radius);
        }

        [TestCase(2, Result = Math.PI * 4)]
        public double InterfaceCall_test(double rad)
        {
            var a = new Circle(rad);
            IFigure t = a;
            return t.GetArea();
        }
    }
}
