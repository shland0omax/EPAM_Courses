using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonLL;

namespace TestNewtonPL
{

    enum en1
    {
        azaza,
        uzuzuz,
        izizizi
    }
    enum en2
    {
        ulululu,
        ecveve,
        eecedc
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            double a = Double.Parse(Console.ReadLine());
            Console.Write("Enter root power:");
            int root = int.Parse(Console.ReadLine());
            Console.Write("Enter accurancy:");
            double accur = Double.Parse(Console.ReadLine());
            double res = NewtonMethod.Execute(a, root, accur);
            Console.WriteLine("Newton method: " + res);
            Console.WriteLine("Math pow: " + Math.Pow(a, (double)1 / root));
            Console.WriteLine(Math.Abs(res - Math.Pow(a, (double)1 / root)) < accur);

        }
    }
}
