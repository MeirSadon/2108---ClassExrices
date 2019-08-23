using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _2108___ClassExrices___3
{
    public class GoButtonConverter : IValueConverter
    {
        public bool CanExecute = true;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if (value.ToString().Length > 2)
                return CanExecute = true;
            return CanExecute = false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
