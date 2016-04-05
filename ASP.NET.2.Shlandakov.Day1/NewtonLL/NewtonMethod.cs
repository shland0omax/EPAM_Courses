using System;

namespace NewtonLL
{
    /// <summary>
    /// Calculates nth root using Newtons method
    /// </summary>
    public static class NewtonMethod
    {
        #region Public methods
        /// <summary>
        /// Calculates nth root
        /// </summary>
        /// <param name="a"> input number to find root of</param>
        /// <param name="n"> root index</param>
        /// <param name="eps"> accurancy of counting</param>
        /// <returns></returns>
        public static double Execute(double a, int n, double eps = 0.00001)
        {
            if (double.IsNaN(a) || double.IsInfinity(a))
            {
                throw new ArgumentException(nameof(a));
            }
            if (double.IsNaN(eps) || eps <= 0 || double.IsNegativeInfinity(eps))
            {
                throw new ArgumentException(nameof(eps));
            }
            if (n == 0 || (a < 0 && ((n % 2) == 0)))
            {
                return double.NaN;
            }
            double x0 = 1;
            bool isPowerNeg = false;
            if (n < 0)
            {
                isPowerNeg = true;
                n *= -1;
            }
            while (true)
            {
                double temp = Power(x0, n - 1);
                double x1 = x0 - (x0 / n) + a / (n * temp);
                if (Math.Abs(x0 - x1) < eps) break;
                x0 = x1;
            }
            if (isPowerNeg) return 1/x0;
            return x0;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// This method helps to calculate power of a number
        /// </summary>
        /// <param name="x">Number to be powered(base)</param>
        /// <param name="y">Power (exponent)</param>
        /// <returns></returns>
        private static double Power(double x, int y)
        {
            if (y == 0)
                return 1;
            if (y % 2 == 1)
                return Power(x, y - 1) * x;
            else
            {
                double z = Power(x, y / 2);
                return z * z;
            }
        }
        #endregion
    }
}
