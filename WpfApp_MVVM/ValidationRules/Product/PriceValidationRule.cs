using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp_MVVM.Properties;

namespace WpfApp_MVVM.ValidationRules.Product
{
    internal class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(float.TryParse(value.ToString(), out var price))
            {
                if (price > 0)
                    return new ValidationResult(true, null);

                return new ValidationResult(false, Resources.ValueMustBeGreaterThan0);
            }

            return new ValidationResult(false, Resources.ValueIsNotANumber);
        }
    }
}
