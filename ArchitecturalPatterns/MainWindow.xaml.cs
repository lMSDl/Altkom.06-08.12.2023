using ArchitecturalPatterns.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArchitecturalPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Page _mvc = new MvcView();
        private readonly Page _mvp = new MvpView();
        private readonly Page _mvvm = new MvvmView();


        private void ToggleButton_Click_MVC(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_mvc);
            ToggleButton_MVC.IsChecked = true;
            ToggleButton_MVP.IsChecked = false;
            ToggleButton_MVVM.IsChecked = false;
        }
        private void ToggleButton_Click_MVP(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_mvp);
            ToggleButton_MVP.IsChecked = true;
            ToggleButton_MVC.IsChecked = false;
            ToggleButton_MVVM.IsChecked = false;
        }
        private void ToggleButton_Click_MVVM(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(_mvvm);
            ToggleButton_MVVM.IsChecked = true;
            ToggleButton_MVP.IsChecked = false;
            ToggleButton_MVC.IsChecked = false;
        }
    }
}