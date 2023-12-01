using JHobby.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class SendMailService : ISendMailService
    {
        public bool SendLetter(string account)
        {
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.gmail.com";

            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("JHobby.THM103@gmail.com", "qbay cfun ebum bjhj");

            var mail = new MailMessage();
            
            mail.Subject = "JHobby帳號註冊成功";
            mail.From = new MailAddress("JHobby.THM103@gmail.com", "JHobbyGM");
            mail.To.Add(account);
            mail.Body = "<h1>恭喜您成為會員~</h1><br><a href=\"https://localhost:7097/member/VerifyMail\" target=\"_blank\">帳號驗證</a>";
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            smtpClient.Send(mail);

            return true;
        }
    }
}