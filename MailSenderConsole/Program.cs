using System;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace MailSenderConsole
{
    class Program
    {                         
        static string pass = "gfhfcrfltrf3ajbbz";
        static void Main(string[] args)
        {
            //создаём письмо
            MailMessage mm = new MailMessage(@"orel13001@yandex.ru", @"orel13001@yandex.ru");
            mm.Subject = "Title massage";
            mm.Body = "Body message.\n Bla-bla-bla!!!";
            mm.IsBodyHtml = false;

            //авторизуемся на smtp-сервере и отправляем письмо

            SmtpClient sc = new SmtpClient("smtp.yandex.ru", 587);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Credentials = new NetworkCredential(@"orel13001@yandex.ru", pass);

            try
            {
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Невозможно отправить письмо " + ex.ToString());
            }
        }
    }
}
