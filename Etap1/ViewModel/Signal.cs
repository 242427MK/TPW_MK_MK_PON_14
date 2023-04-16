using System;
using System.Windows.Input;

namespace ViewModel
{
    internal class Signal : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public Signal(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute();


        public void Execute(object parameter) => this.execute();


        internal void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

