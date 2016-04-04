using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MathPolynomial
{
    /// <summary>
    /// Represents math polynomial
    /// </summary>
    public class Polynomial : IEquatable<Polynomial>
    {
        #region Field and Property

        private readonly double[] elements;

        /// <summary>
        /// Returns max exponent of non-zero elements (returns zero if all coeffs are 0)
        /// </summary>
        public int Degree
        {
            get
            {
                int deg = elements.Length - 1;
                while (deg > 0)
                {
                    if (elements[deg] != 0)
                        return deg;
                    deg--;
                }
                return 0;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates polynomial with coeffs from other polynomial
        /// </summary>
        /// <param name="polynomial">other polynomial</param>
        public Polynomial(Polynomial polynomial) : this(polynomial?.elements)
        {
        }

        /// <summary>
        /// Creates polynomial with specified coefficients (by ascending of exponent)
        /// </summary>
        /// <param name="coefs">coefficients</param>
        public Polynomial(params double[] coefs)
        {
            if (coefs == null)
                throw new ArgumentNullException(nameof(coefs));
            if (coefs.Contains(double.NaN) || coefs.Contains(double.NegativeInfinity) || coefs.Contains(double.PositiveInfinity))
                throw new ArgumentException(nameof(coefs) + " contains invalid value");
            int deg = 4;
            if (deg < coefs.Length) deg = coefs.Length;
            elements = new double[deg];
            if (coefs.Length == 0) return;
            int i = 0;
            foreach (double c in coefs)
            {
                elements[i] = c;
                ++i;
            }
        }
        #endregion

        #region Indexator
        /// <summary>
        /// Returns coefficient for specified exponent (>= 0)
        /// </summary>
        /// <param name="index">exponent parameter</param>
        /// <returns>coefficient for specified exponent</returns>
        public double this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Index should be non-negative number");
                if (elements.Length > index)
                    return elements[index];
                return 0;
            }
        }
        #endregion

        #region Arithmetic operation public methods
        /// <summary>
        /// Addition operation overload
        /// </summary>
        /// <param name="lp">left param</param>
        /// <param name="rp">right param</param>
        /// <returns>Sum polinomial</returns>
        public static Polynomial operator +(Polynomial lp, Polynomial rp)
        {
            return Add(lp, rp);
        }

        /// <summary>
        /// Substraction operation overload
        /// </summary>
        /// <param name="lp">left param</param>
        /// <param name="rp">right param</param>
        /// <returns>Difference polinomial</returns>
        public static Polynomial operator -(Polynomial lp, Polynomial rp)
        {
            return lp + (-rp);
        }

        /// <summary>
        /// Negate operation overload
        /// </summary>
        /// <param name="p">polynomial to be negated</param>
        /// <returns>Negated polinomial</returns>
        public static Polynomial operator -(Polynomial p)
        {
            return Negate(p);
        }

        /// <summary>
        /// Multipliction operation overload
        /// </summary>
        /// <param name="lp">left param</param>
        /// <param name="rp">right param</param>
        /// <returns>Product polinomial</returns>
        public static Polynomial operator *(Polynomial lp, Polynomial rp)
        {
            return Multiply(lp, rp);
        }

        /// <summary>
        /// Sums two polynomial parameters
        /// </summary>
        /// <param name="lp">left param</param>
        /// <param name="rp">right param</param>
        /// <returns>Sum of polynomial</returns>
        public static Polynomial Add(Polynomial lp, Polynomial rp)
        {
            if (lp == null || rp == null)
                throw new ArgumentNullException("Null argument found");
            int length = Math.Max(lp.Degree, rp.Degree);
            double[] resArray = new double[length + 1];
            for (int i = 0; i <= length; ++i)
            {
                resArray[i] = lp[i] + rp[i];
            }
            Polynomial res = new Polynomial(resArray);
            return res;
        }

        /// <summary>
        /// Returns polinomial multipied by -1
        /// </summary>
        /// <param name="p">Input polinomial</param>
        /// <returns>Polinomial multipied by -1</returns>
        public static Polynomial Negate(Polynomial p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            int length = p.Degree;
            double[] resArray = new double[length + 1];
            for (int i = 0; i <= length; ++i)
            {
                resArray[i] = -p[i];
            }
            Polynomial res = new Polynomial(resArray);
            return res;
        }

        /// <summary>
        /// Multiplies two polynomial parameters
        /// </summary>
        /// <param name="lp">left param</param>
        /// <param name="rp">right param</param>
        /// <returns>Composition of polynomial</returns>
        public static Polynomial Multiply(Polynomial lp, Polynomial rp)
        {
            if (lp == null || rp == null)
                throw new ArgumentNullException("Null argument found");
            int len1 = lp.Degree;
            int len2 = rp.Degree;
            double[] resArray = new double[len1 + len2 +1];
            for (int i = 0; i <= len1; ++i)
                for (int j = 0; j <= len2; ++j)
                    resArray[i + j] += lp[i] * rp[j];
            Polynomial res = new Polynomial(resArray);
            return res;
        }
        #endregion

        #region Equality methods

        /// <summary>
        /// Static Equals method
        /// </summary>
        /// <param name="lp">left param</param>
        /// <param name="rp">right param</param>
        /// <returns>true - if equal, false otherwise</returns>
        public static bool Equals(Polynomial lp, Polynomial rp)
        {
            return ((lp == rp) || (((lp != null) && (rp != null))) && lp.Equals(rp));
        }

        /// <summary>
        /// Instance Equals method
        /// </summary>
        /// <param name="other">param</param>
        /// <returns>true - if equal, false otherwise</returns>
        public bool Equals(Polynomial other)
        {
            if (Degree != other?.Degree) return false;
            int len = Degree;
            for (int i = 0; i <= len; i++)
                if (this[i] != other[i])
                    return false;
            return true;
        }

        /// <summary>
        /// Object Equals override method
        /// </summary>
        /// <param name="other">param</param>
        /// <returns>true - if equal, false otherwise</returns>
        public override bool Equals(object other)
        {
            if (!(other is Polynomial)) return false;
            return Equals((Polynomial)other);
        }

        /// <summary>
        /// Tells if variables refer the same object
        /// </summary>
        /// <param name="poly1"></param>
        /// <param name="poly2"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial poly1, Polynomial poly2)
        {
            if ((object)poly1 == (object)poly2) return true;
            return false;
        }

        /// <summary>
        /// Tells if variables refer different objects
        /// </summary>
        /// <param name="poly1"></param>
        /// <param name="poly2"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial poly1, Polynomial poly2)
        {
            return !(poly1 == poly2);
        }

        /// <summary>
        /// Returns object hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return elements?.GetHashCode() ?? 0;
        }
        #endregion

        #region Other public methods
        /// <summary>
        /// Calculates value of polynomial with specified variable value
        /// </summary>
        /// <param name="x">Variable balue</param>
        /// <returns>Value of polynomial</returns>
        public double GetValue(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x))
                throw new ArgumentException("Incorrect value found");
            double res = 0;
            int length = Degree;
            for(int i = 0; i <= length; ++i)
            {
                res += Math.Pow(x, i) * elements[i];
            }
            return res;
        }

        /// <summary>
        /// Returns string representation of current polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            int deg = Degree;
            if (deg == 0) return elements[0].ToString(CultureInfo.InvariantCulture); 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= deg; ++i)
            {
                if (this[i] == 0) continue;
                if (i == 0) sb.Insert(0, this[i]);
                else sb.Insert(0, $"{this[i]}x^{i}");
                if (this[i] > 0) sb.Insert(0, '+');
            }
            return sb.ToString();
        }

        /// <summary>
        /// Double type converter to polynomial
        /// </summary>
        /// <param name="number">Double number</param>
        public static implicit operator Polynomial(double number)
        {
            return new Polynomial(number);
        }
        #endregion
    }
}
