using IntegerFormat;
using System;
using System.Globalization;
using CustomerLL;

namespace TestPL
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte a = -33;
            long b = long.MaxValue;
            Console.WriteLine(a.ToHexString());
            Console.WriteLine(b.ToHexString());
            IntegerHexFormatter f = new IntegerHexFormatter();
            Console.WriteLine(string.Format(f, "Number {0} in hex system: {0:H}", 347457354));
            Console.WriteLine(string.Format(f, "Number {0} in hex system: {0:H}", -46363));
            Customer c = new Customer("Max", "+375294553675", 15);
            Console.WriteLine(string.Format(new CustomerFormatter(), "{0:F}", c));
            Console.WriteLine(string.Format("{0:N}", c));
            Console.WriteLine(string.Format("{0:NPR}", c));
            Console.WriteLine(string.Format("{0:PRN}", c));
            try
            {
                Console.WriteLine(string.Format("{0:NPR1}", c));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
        }
    }
}
