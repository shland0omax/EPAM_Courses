using System;

namespace Figures
{
    public class Triangle: IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle() { }

        public Triangle(double a, double b, double c)
        {
            if (double.IsInfinity(a) || double.IsNaN(a) || a < 0)
                throw new ArgumentException(nameof(a));
            if (double.IsInfinity(b) || double.IsNaN(b) || b < 0)
                throw new ArgumentException(nameof(b));
            if (double.IsInfinity(c) || double.IsNaN(c) || c < 0)
                throw new ArgumentException(nameof(c));
            if (!IsSidesValid(a, b, c)) throw new ArgumentException();
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter()/2;
            return Math.Sqrt(halfPerimeter*(halfPerimeter - SideA)*(halfPerimeter - SideB)*(halfPerimeter - SideC));
        }

        private bool IsSidesValid(double a, double b, double c)
        {
            return !(a+b<=c || a+c <= b || b+c <= a);
        }
    }
}