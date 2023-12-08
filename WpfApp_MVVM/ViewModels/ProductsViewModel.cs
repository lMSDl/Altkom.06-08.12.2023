using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private IService<Product> Service { get; } = new Service<Product>(new ProductFaker());
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


        public ICommand LoadedCommand => new Command(_ => Service.Read().ToList().ForEach(x => Products.Add(x)));
    }
}
