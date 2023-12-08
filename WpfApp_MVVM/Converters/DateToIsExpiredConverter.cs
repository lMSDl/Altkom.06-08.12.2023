using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp_MVVM.Converters
{
    internal class DateToIsExpiredConverter : BaseConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var expirationDate = value as DateTime?;
            return expirationDate < DateTime.Now;
        }
    }
}
