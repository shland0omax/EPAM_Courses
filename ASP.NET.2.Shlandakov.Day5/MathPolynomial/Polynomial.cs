using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPolynomial
{
    /// <summary>
    /// Class that represents a polynomial
    /// </summary>
    public class Polynomial : IEquatable<Polynomial>
    {
        #region Field and Property
        private Dictionary<int, double> coefficients;

        /// <summary>
        /// Max non-zero degree of polynomial
        /// </summary>
        public int Degree
        {
            get
            {
                int deg = coefficients.Count - 1;
                while (deg > 0)
                {
                    if (coefficients[deg] != 0)
                        return deg;
                    deg--;
                }
                return 0;
            }
        }
        #endregion

        #region Constructors
        public Polynomial() : this(0) { }

        public Polynomial(params double[] coefs)
        {
            if (coefs == null)
                throw new ArgumentNullException(nameof(coefs) + " array is null!");
            coefficients = new Dictionary<int, double>();
            if (coefs.Length == 0)
                coefficients.Add(0, 0);
            int i = 0;
            foreach(double c in coefs)
            {
                this[i] = c;
                ++i;
            }
        }

        public Polynomial(Polynomial polynomial)
        {
            coefficients = new Dictionary<int, double>(polynomial.coefficients);
        }
        #endregion

        #region Indexator
        public double this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Index should be non-negative number");
                if (coefficients.ContainsKey(index))
                    return coefficients[index];
                return 0;
            }
            set
            {
                if (double.IsNaN(value) || double.IsNegativeInfinity(value) || double.IsPositiveInfinity(value))
                    throw new ArgumentException("Incorrect coefficient found");
                if (index < 0)
                    throw new IndexOutOfRangeException("Index should be non-negative number");
                if (coefficients.ContainsKey(index))
                    coefficients[index] = value;
                else
                {
                    for (int i = coefficients.Count; i < index; ++i)
                    {
                        coefficients.Add(i, 0);
                    }
                    coefficients.Add(index, value);
                }
            }
        }
        #endregion

        #region Arithmetic operators overload
        public static Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Null argument found");
            int length = Math.Max(poly1.Degree, poly2.Degree);
            Polynomial res = new Polynomial();
            for (int i = 0; i <= length; ++i)
            {
                res[i] = poly1[i] + poly2[i];
            }
            return res;
        }

        public static Polynomial operator -(Polynomial polyMin, Polynomial polySub)
        {
            return polyMin + (-polySub);
        }
        
        public static Polynomial operator -(Polynomial poly)
        {
            if (poly == null)
                throw new ArgumentNullException("Null argument found");
            Polynomial res = new Polynomial();
            int length = poly.Degree;
            for (int i = 0; i <= length; ++i)
            {
                res[i] = -poly[i];
            }
            return res;
        }

        public static Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Null argument found");
            Polynomial res = new Polynomial();
            int len1 = poly1.Degree;
            int len2 = poly2.Degree;
            for(int i = 0; i <= len1; ++i)
                for(int j = 0; j <= len2; ++j)
                    res[i + j] += poly1[i] * poly2[j];
            return res;
        }

        public static Polynomial operator *(Polynomial poly, double multiplier)
        {
            return multiplier*poly;
        }

        public static Polynomial operator *(double multiplier, Polynomial poly)
        {
            if (poly == null)
                throw new ArgumentNullException("Null argument found");
            if (double.IsNaN(multiplier) || double.IsNegativeInfinity(multiplier) || double.IsPositiveInfinity(multiplier))
                throw new ArgumentException("Incorrect coefficient found");
            int len = poly.Degree;
            var res = new Polynomial(poly);
            for(int i = 0; i <= len; ++i)
            {
                res[i] *= multiplier;
            }
            return res; 
        }
        #endregion

        #region Equality methods
        public static bool Equals(Polynomial poly1, Polynomial poly2)
        {
            return ((poly1 == poly2) || ((poly1 != null) && (poly2 != null))) && poly1.Equals(poly2);
        }

        public bool Equals(Polynomial other)
        {
            if (other == null) return false;
            int len = Math.Max(Degree, other.Degree);
            for (int i = 0; i <= len; i++)
                if (this[i] != other[i])
                    return false;
            return true;
        }
            
        public override bool Equals(object other)
        {
            if (!(other is Polynomial)) return false;
            return Equals((Polynomial)other);
        }

        public static bool operator ==(Polynomial poly1, Polynomial poly2)
        {
            if (ReferenceEquals(poly1, poly2)) return true;
            return false;
        }

        public static bool operator !=(Polynomial poly1, Polynomial poly2)
        {
            return !(poly1 == poly2);
        }

        public override int GetHashCode()
        {
            return coefficients.First().GetHashCode() + 331*12;
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
            if (double.IsNaN(x) || double.IsNegativeInfinity(x) || double.IsPositiveInfinity(x))
                throw new ArgumentException("Incorrect value found");
            double res = 0;
            int length = Degree;
            for(int i = 0; i <= length; ++i)
            {
                res += Math.Pow(x, i) * coefficients[i];
            }
            return res;
        }

        public override string ToString()
        {
            int deg = Degree;
            if (deg == 0) return coefficients[0].ToString(); 
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
        #endregion
    }
}
