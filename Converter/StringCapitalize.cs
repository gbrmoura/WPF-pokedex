using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pokedex.Converter {
    public class StringCapitalize : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (string.IsNullOrEmpty(value.ToString())) {
                return string.Empty;
            }

            return char.ToUpper(value.ToString()[0]) + value.ToString().Substring(1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value.ToString();
        }
    }
}
