using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class ProductValidator
    {
        public ProductValidator(Product product)
        {
            product.PropertyChanged += Product_PropertyChanged;
        }

        private void Product_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var product = (Product)sender!;

            switch (e.PropertyName)
            {
                case nameof(Product.Name):
                    ValidateName(product);
                    break;
            }
        }

        private static void ValidateName(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                product.ErrorDictionary[nameof(Product.Name)] = "Pole nie może być puste";
            }
            else if (product.Name.Length > 10)
            {
                product.ErrorDictionary[nameof(Product.Name)] = "Długość nazwy nie może być większa niż 10";
            }
            else
            {
                product.ErrorDictionary.Remove(nameof(Product.Name));
            }
            product.RaiseErrorChanged(nameof(Product.Name));
        }
    }
}
