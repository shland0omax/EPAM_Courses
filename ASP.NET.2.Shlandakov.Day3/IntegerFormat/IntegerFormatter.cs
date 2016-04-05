using System;
using System.Text;
using System.Numerics;


//Примечание!
//Реализовал это задание двумя способами:
//1. IntegerFormatter - static-класс, предоставляющий метод расширения, перегруженный для всех целочисленных типов
//2. IntegerHexFormatter - поставщик формата для форматированного вывода числа в шестнадцатиричной записи (Работает только для String.Format)
namespace IntegerFormat
{
    /// <summary>
    /// Returns hex string equivalent for integer numbers
    /// </summary>
    public static class IntegerFormatter
    {
        public static string ToHexString(this byte num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this sbyte num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this short num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this int num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this long num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this ushort num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this uint num)
        {
            return GetHex(num);
        }

        public static string ToHexString(this ulong num)
        {
            return GetHex(num);
        }

        /// <summary>
        /// Calculates hex view of number
        /// </summary>
        /// <param name="number">Integer to be formatted</param>
        /// <param name="isNegative">Was it negative in origin?</param>
        /// <returns>Formatted string with hex view</returns>
        internal static string GetHex(BigInteger number)
        {
            if (number == 0) return "0";
            StringBuilder sb = new StringBuilder();
            bool isNegative = number < 0;
            BigInteger.Abs(number);
            while (number > 0)
            {
                byte temp = (byte)(number % 16);
                number /= 16;
                if (temp > 9)
                {
                    sb.Insert(0, (char)(temp + 55));

                }
                else
                {
                    sb.Insert(0, (char)(temp + 48));
                }
            }
            if (isNegative)
            {
                sb.Insert(0, "-");
            }
            return sb.ToString();
        }

    }

    /// <summary>
    /// Provides format for hex equivalent of integer
    /// </summary>
    public class IntegerHexFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) return null;
            if (!formatProvider.Equals(this)) return null;
            if (!(format == "H")) return null;

            string res = String.Empty;

            if (arg is sbyte)
            {
                sbyte a = (sbyte)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is short)
            {
                short a = (short)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is int)
            {
                int a = (int)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is long)
            {
                long a = (long)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is byte)
            {
                byte a = (byte)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is ushort)
            {
                ushort a = (ushort)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is uint)
            {
                uint a = (uint)arg;
                return IntegerFormatter.GetHex(a);
            }
            if (arg is ulong)
            {
                ulong a = (ulong)arg;
                return IntegerFormatter.GetHex(a);
            }
            else return null;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
