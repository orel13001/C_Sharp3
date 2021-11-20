using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SendMailWPF.ConstData;

namespace SendMailWPF.Logic
{
    public class EmailWork
    {
        string smtp_server = ConstParametrForMail.SMTP_Server;
        int port = ConstParametrForMail.Port;
        string mailFrom = ConstParametrForMail.MailFrom;
        string loginSMTP = ConstParametrForMail.LoginSMTP;

        string pass_smtp;
        public string Pass_SMTP { set => pass_smtp = value; }

        MailMessage Message { get; set; }

        public EmailWork (string pass)
        {
            Pass_SMTP = pass;
        }

        public void CreateEmail(string To, string Title, string Body)
        {
            Message = new MailMessage(mailFrom, To);
            Message.Subject = Title;
            Message.Body = Body;
            Message.IsBodyHtml = false;
        }

        public bool SendEmail()
        {
            using (SmtpClient sc = new SmtpClient(smtp_server, port))
            {
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Credentials = new NetworkCredential(loginSMTP, pass_smtp);
                try
                {
                    sc.Send(Message);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        

        
                    
    }
}
