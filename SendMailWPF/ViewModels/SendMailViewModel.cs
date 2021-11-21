using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SendMailWPF.Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SendMailWPF.ConstData;
using SendMailWPF.Views;
using System.Windows.Data;

namespace SendMailWPF.ViewModels
{
    internal class SendMailViewModel : INotifyPropertyChanged
    {
        private bool isAccess = false;
        private int activeTabIndex = 0;
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
        public string MailTo { get; set; }  
        public string MailTitle { get; set; }
        public string MailMessage { get; set; } 
        public string MailPassword { get; set; }    
        
        /// <summary>
        /// получение номера активной вкладки
        /// </summary>
        public int ActiveTabIndex {
            get => activeTabIndex; 
            set
            {
                activeTabIndex = value;
                OnPropertyChanged("activeTabIndex");
            }
        }

        private string PrevTabItem
        {
            get
            {
                if (ActiveTabIndex <= 0)
                {
                    return "";
                }
                else
                {
                    return $" {ActiveTabIndex - 1}";
                }
            }
        }
        /// <summary>
        /// получение номера следующей вкладки
        /// </summary>
        private string NextTabItem
        {
            get
            {
                if (ActiveTabIndex >= 3)
                {
                    return "";
                }
                else
                {
                    return $" {ActiveTabIndex + 1}";
                }
            }
        }


        public ICommand AccessCommand => new BaseCommand(LoginAccessExecute);
        public ICommand SendMailCommand => new BaseCommand(SendMailExecute, SendMailExecuted);



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

        private void SendMailExecute(object obj)
        {

            EmailWork email = new EmailWork(MailPassword);

            SendEndWindow sew = new SendEndWindow();
            try
            {
                email.CreateEmail(MailTo, MailTitle, MailMessage);
                if (email.SendEmail())
                {
                    sew.lblSendEnd.Content = ConstParametrForMail.SuccessSend;
                }
                else
                {
                    sew.lblSendEnd.Content = ConstParametrForMail.BadSend;
                }
                sew.ShowDialog();
            }
            catch (Exception ex)
            {
                sew.lblSendEnd.Content = ConstParametrForMail.SuccessSend + ex.ToString();
                sew.ShowDialog();
            }
        }

        private bool SendMailExecuted(object obj)
        {
            return (MailPassword != "" && MailPassword != null) && (MailTo != "" && MailTo != null);
        }


    }
}
