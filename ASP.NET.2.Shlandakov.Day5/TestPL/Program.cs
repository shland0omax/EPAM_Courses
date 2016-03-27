using System;
using MathPolynomial;

namespace TestPL
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Polynomial(1, 1);
            var b = new Polynomial(-1, 1);
            Console.WriteLine((a*b).ToString());
            var c = new Polynomial(1, -5, 3, 2);
            var d = c;
            var e = new Polynomial(1, -5, 3, 2);
            var f = new Polynomial(3, 5, 6);
            Console.WriteLine(c.GetValue(3));
            Console.WriteLine(-c);
            Console.WriteLine(a+b+c);
            Console.WriteLine(c == d);
            Console.WriteLine(c.Equals(e));
            Console.WriteLine(c == e);
            Console.WriteLine(f*e*a);
            Console.WriteLine(f[2]);
        }
    }
}
