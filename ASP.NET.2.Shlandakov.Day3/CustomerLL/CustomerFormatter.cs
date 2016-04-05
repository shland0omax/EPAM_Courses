using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomerLL
{
    /// <summary>
    /// Класс предоставляет дополнительный форматированный вывод для объектов класса Customer
    /// </summary>
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Возвращает особое строковое представление объекта класса Customer
        /// </summary>
        /// <param name="format">Строка формата</param>
        /// <param name="arg">Форматируемый объект</param>
        /// <param name="formatProvider">Поставщик формата</param>
        /// <returns>Особое строковое представление</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) return null;
            if (!formatProvider.Equals(this)) return null;
            if (!(format == "F")) return null;
            if (!(arg is Customer)) return null;

            Customer c = arg as Customer;
            NumberFormatInfo f = new NumberFormatInfo();
            f.CurrencySymbol = "$";
            return string.Format(f, "Hey, wat's up? Would you like to buy some awesome bike chains for {1:C2}/each? You can call me: {2}. {0}", c.Name, c.Revenue, c.ContactPhone);            
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
