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
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private IService<Product> Service { get; } = new Service<Product>(new ProductFaker());
        private Product? selectedProduct;
        public ObservableCollection<Product> Products { get; set; } = [];


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


        public ICommand EditCommand => new DialogCommand<ProductViewModel>(
            () => new ProductViewModel() { Product = (Product)SelectedProduct!.Clone() },
            vm =>
            {
                int index = Products.IndexOf(SelectedProduct!);
                Products.RemoveAt(index);
                Products.Insert(index, vm.Product);
            },
            _ => SelectedProduct is not null);

        public ICommand AddCommand => new DialogCommand<ProductViewModel>(
            () => new ProductViewModel() { Product = new Product() },
            vm => Products.Add(vm.Product));

        public ICommand DeleteCommand => new Command(_ => Products.Remove(SelectedProduct!),
                                                     _ => SelectedProduct is not null);
        public ICommand LoadedCommand => new Command(_ =>
        {
            Products.Clear();
            Service.Read().ToList().ForEach(x => Products.Add(x));
        });
    }
}
