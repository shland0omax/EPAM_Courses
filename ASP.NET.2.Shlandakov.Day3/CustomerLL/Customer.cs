using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLL
{
    public class Customer : IFormattable
    {
        #region Properties
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }
        #endregion

        //Constructor
        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }

        #region public methods
        /// <summary>
        /// Return formatted string equivalent
        /// </summary>
        /// <returns>Formatted string equivalent</returns>
        public override string ToString()
        {
            return ToString("NPR", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Reterns string equivalent with format set
        /// </summary>
        /// <param name="format">Output format</param>
        /// <returns>Formatted string equivalent</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///  Reterns string equivalent with format set and specified formatting provider
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns>String equivalent</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "NPR";
            }
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.InvariantCulture;
            }
            int multipleFormat = 0;
            StringBuilder sb = new StringBuilder("Customer record: ");
            HashSet<char> formatParams = new HashSet<char>(format.ToUpper().ToCharArray());
            foreach(char param in formatParams)
            {
                switch (param){
                    case 'N':
                        if (multipleFormat > 0)
                            sb.Append(", ");
                        sb.Append(Name.ToString(formatProvider));
                        multipleFormat++;
                        break;
                    case 'P':
                        if (multipleFormat > 0)
                            sb.Append(", ");
                        sb.Append(ContactPhone.ToString(formatProvider));
                        multipleFormat++;
                        break;
                    case 'R':
                        if (multipleFormat > 0)
                            sb.Append(", ");
                        NumberFormatInfo f = new NumberFormatInfo();
                        f.NumberGroupSeparator = ",";
                        sb.Append(Revenue.ToString("N2", f));
                        multipleFormat++;
                        break;
                    default:
                        throw new ArgumentException(string.Format("Type of {0} format is not defined", param));
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
