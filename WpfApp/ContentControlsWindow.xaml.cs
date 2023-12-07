using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ContentControlsWindow.xaml
    /// </summary>
    public partial class ContentControlsWindow : Window
    {
        public IEnumerable<Product> Products { get; set; }

        public Product? SelectedProduct { get; set; }

        public ContentControlsWindow()
        {
            InitializeComponent();

            DataContext = this;
            Products = new Service<Product>(new ProductFaker()).Read().Concat(new List<Product>() { new Product { Name = "..", Priority = true } });
        }

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
