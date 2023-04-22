using System;
using System.Windows.Input;

namespace ViewModel
{
    internal class Signal : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action action;

        public Signal(Action execute)
        {
            this.action = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}

