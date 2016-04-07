using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Rectangle: IFigure
    {
        public virtual double Width { get; }
        public double Height { get; }

        public Rectangle() { }

        public Rectangle(double width, double height)
        {
            if (double.IsInfinity(width) || double.IsNaN(width) || width < 0)
                throw new ArgumentException(nameof(width));
            if (double.IsInfinity(height) || double.IsNaN(height) || height < 0)
                throw new ArgumentException(nameof(height));
            Width = width;
            Height = height;
        }

        public virtual double GetPerimeter()
        {
            return 2*(Height + Width);
        }

        public virtual double GetArea()
        {
            return Height*Width;
        }
    }
}
