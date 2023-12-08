using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    public class ProductsViewModel : NotifyPropertyChanged
    {
        private IAsyncService<Product> Service { get; } = new AsyncService<Product>(new ProductFaker());
        private Product? selectedProduct;
        private bool isLoading;

        public ObservableCollection<Product> Products { get; set; } = [];


        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => isLoading; set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }



        public ICommand EditCommand => new DialogCommand<ProductViewModel>(
            () => new ProductViewModel((Product)SelectedProduct!.Clone() ),
            vm =>
            {
                int index = Products.IndexOf(SelectedProduct!);
                Products.RemoveAt(index);
                Products.Insert(index, vm.Product);
            },
            _ => SelectedProduct is not null);

        public ICommand AddCommand => new DialogCommand<ProductViewModel>(
            () => new ProductViewModel(new Product()),
            vm => Products.Add(vm.Product));

        public ICommand DeleteCommand => new Command(_ => Products.Remove(SelectedProduct!),
                                                     _ => SelectedProduct is not null);
        public ICommand LoadedCommand => new AsyncCommand(async _ =>
        {
            IsLoading = true;
            try
            {
                Products.Clear();
                var products = await Service.ReadAsync();
                products.ToList().ForEach(x => Products.Add(x));
            }
            finally { IsLoading = false; }
        });
    }
}
