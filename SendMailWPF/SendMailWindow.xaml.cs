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

namespace SendMailWPF
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
            using (MailMessage mm = new MailMessage(@"orel13001@yandex.ru", @"orel13001@yandex.ru"))
            {
                mm.Subject = "Title massage";
                mm.Body = "Body message.\n Bla-bla-bla!!!";
                mm.IsBodyHtml = false;

                //авторизуемся на smtp-сервере и отправляем письмо
                using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 587))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.Credentials = new NetworkCredential(@"orel13001@yandex.ru", pass);

                    try
                    {
                        sc.Send(mm);
                        MessageBox.Show("Письмо отправлено");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                    } 
                } 
            }
            
        }
    }
}
