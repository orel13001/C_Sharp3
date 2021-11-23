using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SendMailWPF.ViewModels
{
    internal class BaseCommand : ICommand
    {
        private Action<object> execute;
        private Func<object,bool> canExecute;

        public BaseCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute; 
            this.canExecute = canExecute;  
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add {CommandManager.RequerySuggested += value;}
            remove {CommandManager.RequerySuggested -= value;}
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
