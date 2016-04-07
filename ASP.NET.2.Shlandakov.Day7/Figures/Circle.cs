using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle: IFigure
    {
        public double Radius { get; }

        public Circle() { }

        public Circle(double radius)
        {
            if (double.IsInfinity(radius) || double.IsNaN(radius) || radius < 0)
                throw new ArgumentException(nameof(radius));
            Radius = radius;
        }

        public double GetPerimeter()
        {
            return Radius*2*Math.PI;
        }

        public double GetArea()
        {
            return Math.PI*Math.Pow(Radius, 2);
        }
    }
}
