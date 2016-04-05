using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclideanAlgoLL
{
    /// <summary>
    /// Calculates GCD for int numbers with Euclidean or Binary methods
    /// </summary>
    public static class GcdCalculator
    {
        private delegate int GcdCalculate(int x, int y);

        #region Public Metods
        /// <summary>
        /// Euclidean method of GCD calculation
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD</returns>
        public static int GcdEuclidean(int a, int b)
        {
            return CalculateEuclidean(a, b);
        }

        /// <summary>
        /// Euclidean method of GCD calculation for multiple numbers
        /// </summary>
        /// <param name="numbers">input numbers</param>
        /// <returns>GCD</returns>
        public static int GcdEuclidean(params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            if (numbers.Length == 0) throw new ArgumentException(nameof(numbers) + " is empty");
            if (numbers.Length == 1) return Math.Abs(numbers[0]);
            return CalculateMultiple(CalculateEuclidean, numbers);
        }

        /// <summary>
        /// Euclidean method of GCD calculation with time counting(in tics)
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="tics">time</param>
        /// <returns>GCD</returns>
        public static int GcdEuclidean(int a, int b, out long tics)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = CalculateEuclidean(a, b);
            tics = sw.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Euclidean method of GCD calculation for multiple numbers with time counting
        /// </summary>
        /// <param name="tics">time (in tics)</param>
        /// <param name="numbers">numbers</param>
        /// <returns>GCD</returns>
        public static int GcdEuclidean(out long tics, params int[] numbers)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = GcdEuclidean(numbers);
            tics = sw.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Binary method of GCD calculation
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>GCD</returns>
        public static int GcdBinary(int a, int b)
        {
            return CalculateBinary(a, b);
        }

        /// <summary>
        /// Binary method of GCD calculation for multiple numbers
        /// </summary>
        /// <param name="numbers">input numbers</param>
        /// <returns>GCD</returns>
        public static int GcdBinary(params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            if (numbers.Length == 0) throw new ArgumentException(nameof(numbers) + " is empty");
            if (numbers.Length == 1) return Math.Abs(numbers[0]);
            return CalculateMultiple(CalculateBinary, numbers);
        }

        /// <summary>
        /// Binary method of GCD calculation with time counting(in tics)
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="tics">time</param>
        /// <returns>GCD</returns>
        public static int GcdBinary(int a, int b, out long tics)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = CalculateEuclidean(a, b);
            tics = sw.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Binary method of GCD calculation for multiple numbers with time counting
        /// </summary>
        /// <param name="tics">time (in tics)</param>
        /// <param name="numbers">numbers</param>
        /// <returns>GCD</returns>
        public static int GcdBinary(out long tics, params int[] numbers)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int res = GcdBinary(numbers);
            tics = sw.ElapsedTicks;
            return res;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Service method for calculating GCD for multiple numbrs
        /// </summary>
        /// <param name="calculate">Calculate method</param>
        /// <param name="numbers">numbers to calculate GCD</param>
        /// <returns></returns>
        private static int CalculateMultiple(GcdCalculate calculate, int[] numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; ++i)
            {
                result = calculate(result, numbers[i]);
            }
            return result;
        }

        /// <summary>
        /// Euclidean method of GCD calculating
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Stein method of GCD calculating
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
