using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ContentControlsWindow.xaml
    /// </summary>
    public partial class ContentControlsWindow : Window, INotifyPropertyChanged
    {
        private Product? selectedProduct;

        public ObservableCollection<Product> Products { get; set; }

        public Product? SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProduct)));
            }
        }

        public ContentControlsWindow()
        {
            InitializeComponent();

            DataContext = this;
            Products = new ObservableCollection<Product>(new Service<Product>(new ProductFaker()).Read().Concat(new List<Product>() { new Product { Name = "..", Priority = true } }));

            _ = Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {

                    await Task.Delay(2500);

                    Application.Current.Dispatcher.Invoke(() =>
                    Products.Add(new Product { Name = i.ToString() }));
                }
            });

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            var descriptors = ((DataGrid)sender).Items.SortDescriptions;
            descriptors.Clear();
            descriptors.Add(new System.ComponentModel.SortDescription(nameof(Product.Priority), System.ComponentModel.ListSortDirection.Descending));
            descriptors.Add(new System.ComponentModel.SortDescription(e.Column.SortMemberPath, System.ComponentModel.ListSortDirection.Ascending));

            e.Handled = true;
        }
    }
}
