using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_MVVM.Converters
{
    internal class BoolToVisibilityConverter : BaseConverter
    {
        public bool Invert { get; set; }
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as bool? == Invert ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
