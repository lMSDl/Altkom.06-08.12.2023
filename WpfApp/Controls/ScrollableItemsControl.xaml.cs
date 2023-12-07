using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for ProductItemsControl.xaml
    /// </summary>
    public partial class ScrollableItemsControl : UserControl
    {
        public ScrollableItemsControl()
        {
            InitializeComponent();
        }

        public static DependencyProperty MyItemsSourceProperty { get; } = DependencyProperty.Register(nameof(MyItemsSource), typeof(IEnumerable<object>), typeof(ScrollableItemsControl));
        public IEnumerable<object> MyItemsSource { get => (IEnumerable<object>)GetValue(MyItemsSourceProperty); set => SetValue(MyItemsSourceProperty, value); }

        public static DependencyProperty MyItemTemplateProperty { get; } = DependencyProperty.Register(nameof(MyItemTemplate), typeof(DataTemplate), typeof(ScrollableItemsControl));
        public DataTemplate MyItemTemplate { get => (DataTemplate)GetValue(MyItemTemplateProperty); set => SetValue(MyItemTemplateProperty, value); }
    }
}
