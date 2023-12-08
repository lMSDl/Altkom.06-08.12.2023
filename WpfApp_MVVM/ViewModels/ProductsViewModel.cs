using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private Product? selectedProduct;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product> {};

        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProduct)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
