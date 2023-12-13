using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace JHobby.Service.Implements
{
    public class SendMailService : ISendMailService
    {
        private readonly ICommonService _commonService;
        public SendMailService(ICommonService commonService)
        {
            _commonService = commonService;
        }
        public bool SendLetter(string _path, string account)
        {
            string registerDate = DateTime.Now.ToString("yyyy-MM-dd");
            string encryption = $"{account}&{registerDate}";
            string verify = _commonService.Encrypt(encryption);
            verify = _commonService.EncodeBase64Url(verify);
            string mailName = "_VerifyMailPartial";
            EmailReplaceModel mailReplaceData = new EmailReplaceModel();
            mailReplaceData.Verify = verify;
            string body = _commonService.setReplacedEmailData(_path, mailName, mailReplaceData);

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.gmail.com";

            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("JHobby.THM103@gmail.com", "dfgr qjhw rbqz zold");

            var mail = new MailMessage();

            mail.Subject = "94Hobby帳號註冊成功";
            mail.From = new MailAddress("JHobby.THM103@gmail.com", "94HobbyGM");
            mail.To.Add(account);
            //mail.Body = $"<h1>恭喜您成為會員~</h1><br><a href=\"https://localhost:7097/member/VerifyMail/{verify}\" target=\"_blank\">帳號驗證</a>";
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            smtpClient.Send(mail);
            return true;
        }

        public bool ResetPwdSendLetter(string _path,string account, string newPwd)
        {
            SmtpClient smtpClient = new SmtpClient();
            EmailReplaceModel mailReplaceData = new EmailReplaceModel();
            mailReplaceData.NewPwd= newPwd;
            string mailName = "_ResetPwdMailPartial";
            string body = _commonService.setReplacedEmailData(_path, mailName, mailReplaceData);

            smtpClient.Host = "smtp.gmail.com";

            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("JHobby.THM103@gmail.com", "dfgr qjhw rbqz zold");

            var mail = new MailMessage();

            mail.Subject = "94Hobby會員密碼重置";
            mail.From = new MailAddress("JHobby.THM103@gmail.com", "94HobbyGM");
            mail.To.Add(account);
            //mail.Body = $"您的新密碼為{newPwd}";
            mail.Body=body;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            smtpClient.Send(mail);

            return true;
        }
    }
}