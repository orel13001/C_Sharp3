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
            string pass = pswdBox.Password;

            //создаём письмо
            using (MailMessage mm = new MailMessage(ConstParametrForMail.MailFrom, @"orel13001@yandex.ru"))
            {
                mm.Subject = "Title massage";
                mm.Body = "Body message.\n Bla-bla-bla!!!";
                mm.IsBodyHtml = false;

                //авторизуемся на smtp-сервере и отправляем письмо
                using (SmtpClient sc = new SmtpClient(ConstParametrForMail.SMTP_Server, ConstParametrForMail.Port))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.Credentials = new NetworkCredential(ConstParametrForMail.LoginSMTP, pass);
                    SendEndWindow sew = new SendEndWindow();
                    try
                    {
                        sc.Send(mm);
                        sew.lblSendEnd.Content = "Письмо отправлено";
                        sew.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        sew.lblSendEnd.Content = "Невозможно отправить письмо " + ex.ToString();
                        sew.ShowDialog();

                    } 
                } 
            }
            
        }
    }
}
