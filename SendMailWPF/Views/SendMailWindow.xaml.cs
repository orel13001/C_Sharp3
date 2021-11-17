using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using SendMailWPF.ConstData;
using SendMailWPF.Logic;

namespace SendMailWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SendMailWindow : Window
    {
        private int ActiveTabItem { get => tcSendMail.SelectedIndex; }
        private string PrevTabItem
        {
            get 
            {
                if (ActiveTabItem <= 0)
                {
                    return "";
                }
                else
                {
                    return $" {ActiveTabItem - 1}";
                }
            }
        }

        private string NextTabItem
        {
            get
            {
                if (ActiveTabItem >= tcSendMail.Items.Count-1)
                {
                    return "";
                }
                else
                {
                    return $" {ActiveTabItem + 1}";
                }
            }
        }


        public SendMailWindow()
        {
            InitializeComponent();
            SetBtnName();

        }

        

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {

            EmailWork email = new EmailWork(pswdBox.Password);

            email.CreateEmail(To.Text, Title.Text, BodyMail.Text);
            SendEndWindow sew = new SendEndWindow();
            try
            {
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

        private void tcSendMail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetBtnName();
        }

        private void SetBtnName()
        {
            PrevNextButton.PrevBtnName = "Prev" + PrevTabItem;
            PrevNextButton.NextBtnName = "Next" + NextTabItem;
        }

        //private void PrevNextButton_PrevBtnClick(object sender, EventArgs e)
        //{
            
             
        //}

        //private void PrevNextButton_NextBtnClick(object sender, EventArgs e)
        //{
            
        //}

        private void PrevNextButton_PrevBtnClick(object sender, RoutedEventArgs e)
        {
            if (tcSendMail.SelectedIndex >= 0)
            {
                tcSendMail.SelectedIndex--;
            }
        }

        private void PrevNextButton_NextBtnClick(object sender, RoutedEventArgs e)
        {
            if (tcSendMail.SelectedIndex <= tcSendMail.Items.Count - 1)
            {
                tcSendMail.SelectedIndex++;
            }
        }
    }
}
