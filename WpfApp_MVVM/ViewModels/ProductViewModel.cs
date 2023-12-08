using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.Commands;

namespace WpfApp_MVVM.ViewModels
{
    internal class ProductViewModel : NotifyPropertyChanged
    {
        public Product Product { get; set; }

        public ICommand SaveCommand => new Command(window => ((Window)window).DialogResult = true);

    }
}
