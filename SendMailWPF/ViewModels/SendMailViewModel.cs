using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SendMailWPF.Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SendMailWPF.ViewModels
{
    internal class SendMailViewModel : INotifyPropertyChanged
    {
        private bool isAccess = false;
        public bool IsAccess
        {
            get => isAccess;
            set
            {
                isAccess = value;
                OnPropertyChanged("isAccess");
            }
        } 
        public string Login { get; set; }
        public string Password { get; set; }
        


        public ICommand AccessCommand => new BaseCommand(LoginAccessExecute);

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void LoginAccessExecute(object obj)
        {
            if (AccessProgramm.IsAccessProgramm(Login, Password))
            {
                IsAccess = true;
            }
            else
            {
                IsAccess = false;
            }
        }

    }
}
