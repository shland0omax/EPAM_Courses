using System;

namespace Figures
{
    public class Square: Rectangle
    {
        public override double Width { get; }

        public Square() { }

        public Square(double side) 
        {
            if (double.IsInfinity(side) || double.IsNaN(side) || side < 0)
                throw new ArgumentException(nameof(side));
            Width = side;
        }

        public override double GetPerimeter()
        {
            return 4*Width;
        }

        public override double GetArea()
        {
            return Width*Width;
        }
    }
}