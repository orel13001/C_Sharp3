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
        public SendMailWindow()
        {
            InitializeComponent();
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
    }
}
