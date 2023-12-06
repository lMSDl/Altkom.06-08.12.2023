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
    /// Interaction logic for ControlsWindow.xaml
    /// </summary>
    public partial class ControlsWindow : Window
    {
        public ControlsWindow()
        {
            InitializeComponent();


            MyTextBlock.Inlines.Add(new Run("bold") { FontWeight = FontWeights.Bold });

            //MySlider.Value = MyTextBox.Text.Length;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           var result =  MessageBox.Show("Should I disappear?", "Button Click", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes && sender is Button myButton)
            {
                myButton.Visibility = Visibility.Hidden;

                Task.Delay(2500).ContinueWith(x => Application.Current.Dispatcher.Invoke(() => myButton.Visibility = Visibility.Collapsed));
                Task.Delay(5000).ContinueWith(x => Application.Current.Dispatcher.Invoke(() => myButton.Visibility = Visibility.Visible));
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(Checkbox1.IsChecked == true && Checkbox2.IsChecked == true && Checkbox3.IsChecked == true)
                MainCheckbox.IsChecked = true;
            else if (Checkbox1.IsChecked == false && Checkbox2.IsChecked == false && Checkbox3.IsChecked == false)
                MainCheckbox.IsChecked = false;
            else
                MainCheckbox.IsChecked = null;
        }

        private void MainCheckbox_Click(object sender, RoutedEventArgs e)
        {
            Checkbox1.IsChecked = Checkbox2.IsChecked = Checkbox3.IsChecked = MainCheckbox.IsChecked ?? false;
        }
    }
}
