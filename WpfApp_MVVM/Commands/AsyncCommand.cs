using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp_MVVM.Commands
{
    internal class AsyncCommand : ICommand
    {
        private readonly Func<object?, Task> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public AsyncCommand(Func<object?, Task> execute)
        {
            _execute = execute;
        }
        public AsyncCommand(Func<object?, Task> execute, Func<object?, bool> canExecute) : this(execute)
        {
            _canExecute = canExecute;
        }


        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private bool _isWorking;

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? !_isWorking;
        }

        public void Execute(object? parameter)
        {
            _isWorking = true;
            _execute(parameter).ContinueWith(x => _isWorking = false);
        }
    }
}
