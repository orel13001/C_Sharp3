using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailWPF.ConstData
{
    public static class ConstParametrForMail
    {
        public static string SMTP_Server { get => "smtp.yandex.ru"; }
        public static int Port { get => 587; }
        public static string MailFrom { get => @"orel13001@yandex.ru"; }
        public static string LoginSMTP { get => @"orel13001@yandex.ru"; }
        public static string SuccessSend { get => @"Письмо отправлено!"; }
        public static string BadSend { get => @"Ошибка отправки письма!"; }


    }
}
