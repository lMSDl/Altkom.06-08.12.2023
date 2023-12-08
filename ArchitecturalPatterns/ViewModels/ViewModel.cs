using ArchitecturalPatterns.Commands;
using ArchitecturalPatterns.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArchitecturalPatterns.ViewModels
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private string inputValue = "";

        public ViewModel()
        {
            Model = new SomeModel() {  };

            SaveCommand = new Command(x => Model.Value = InputValue, x => Model.Value != InputValue);
            LoadCommand = new Command(x => InputValue = Model.Value, x => Model.Value != InputValue);
        }

        public SomeModel Model { get; set; }
        public string InputValue
        {
            get => inputValue; set
            {
                inputValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InputValue)));

                //SaveCommand.RaiseCanExecuteChanged();
                //LoadCommand.RaiseCanExecuteChanged();
            }
        }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
