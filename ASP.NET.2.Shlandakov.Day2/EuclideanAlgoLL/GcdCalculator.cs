using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дополнительно
//В public-методах, как можно заметить, возможны повторения кода валидации.
//Сделано это для того, чтобы не выполнять валидацию в private-методах, что, на мой взгляд, является плохим стилем
//Делегат, добавленный в класс, достаточно универсальным и легко можнет быть применен в случае добавления новых
//методов вычисления НОД

namespace EuclideanAlgoLL
{
    public static class GcdCalculator
    {

        private delegate int GCDCalculator(int x, int y);

        #region Public Metods

        public static int GCDEuclidean(int a, int b)
        {
            return CalculateEuclidean(a, b);
        }

        public static int GCDEuclidean(params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            if (numbers.Length == 0) throw new ArgumentException(nameof(numbers) + " is empty");
            if (numbers.Length == 1) return Math.Abs(numbers[0]);
            return CalculateMultiple(CalculateEuclidean, numbers);
        }

        public static int GCDEuclidean(int a, int b, out long tics)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = CalculateEuclidean(a, b);
            tics = sw.ElapsedTicks;
            return res;
        }

        public static int GCDEuclidean(out long tics, params int[] numbers)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = GCDEuclidean(numbers);
            tics = sw.ElapsedTicks;
            return res;
        }

        public static int GCDBinary(int a, int b)
        {
            return CalculateBinary(a, b);
        }

        public static int GCDBinary(params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            if (numbers.Length == 0) throw new ArgumentException(nameof(numbers) + " is empty");
            if (numbers.Length == 1) return Math.Abs(numbers[0]);
            return CalculateMultiple(CalculateBinary, numbers);
        }

        public static int GCDBinary(int a, int b, out long tics)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = CalculateEuclidean(a, b);
            tics = sw.ElapsedTicks;
            return res;
        }

        public static int GCDBinary(out long tics, params int[] numbers)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = GCDBinary(numbers);
            tics = sw.ElapsedTicks;
            return res;
        }
        #endregion

        #region Private methods

        private static int CalculateMultiple(GCDCalculator calculator, int[] numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; ++i)
            {
                result = calculator(result, numbers[i]);
            }
            return result;
        }

        private static int CalculateEuclidean(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        private static int CalculateBinary(int a, int b)
        {
            int shift = 0;
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0) return b;
            if (b == 0) return a;

            while (((a | b) & 1) == 0)
            {
                a >>= 1;
                b >>= 1;
                shift++;
            }
            while ((a & 1) == 0)
            {
                a >>= 1;
            }
            while (b != 0)
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }
                if (a > b)
                {
                    int temp = b; b = a; a = temp;
                }
                b -= a;
            }
            return a << shift;
        }
        #endregion
    }
}
