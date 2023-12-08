using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp_MVVM.ViewModels;

namespace WpfApp_MVVM.Commands
{
    internal class DialogCommand<T> : ICommand
    {
        private readonly Action<T> _positiveAction;
        private readonly Func<T> _dataContext;
        private readonly Func<object?, bool>? _canExecute;

        public DialogCommand(Func<T> dataContext, Action<T> positiveAction)
        {
            _positiveAction = positiveAction;
            _dataContext = dataContext;
        }
        public DialogCommand(Func<T> dataContext, Action<T> positiveAction, Func<object?, bool> canExecute) : this(dataContext, positiveAction)
        {
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            Window window = (Window)Activator.CreateInstance((Type)parameter!)!;
            window.DataContext = _dataContext();

            if (window.ShowDialog() == true)
            {
                _positiveAction((T)window.DataContext);
            }
        }
    }
}
