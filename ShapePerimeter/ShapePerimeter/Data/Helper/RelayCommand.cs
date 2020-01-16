using System;
using System.Windows.Input;

namespace ShapePerimeter.Data.Helper
{
    public class RelayCommand<T> : ICommand
    {
        readonly Action<T> _action;
        readonly Predicate<T> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> action) { _action = action; }
        public RelayCommand(Action<T> action, Predicate<T> canExecute) { _action = action; _canExecute = canExecute; }

        public bool CanExecute(object parameter) { return _canExecute != null ? true : parameter is T && _canExecute((T)parameter); }
        public void Execute(object parameter) { _action((T)parameter); }

    }

    public class RelayCommand : ICommand
    {
        readonly Action<object> _action;
        readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> action) { _action = action; }
        public RelayCommand(Action<object> action, Predicate<object> canExecute) { _action = action; _canExecute = canExecute; }

        public bool CanExecute(object parameter) { return _canExecute != null ? true : parameter != null && _canExecute(parameter); }
        public void Execute(object parameter) { _action(parameter); }

    }
}
