using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public void SendTest(string Name,string Email)
        {
            
        }
            [HttpPost]
        public JsonResult SendEmail()
        {
            string name = Request.Form["Name"];
            string email = Request.Form["Email"];
            string subject = Request.Form["Subject"];
            string message = Request.Form["Message"];

            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress("vigorhan@gmail.com", "宏羿布業有限公司");

            //收信者email
            mail.To.Add(email);

            //設定優先權
            mail.Priority = MailPriority.Normal;

            //標題
            mail.Subject = subject;

            //內容
            mail.Body = "<h1>" + message + "</h1> ";

            //內容使用html
            mail.IsBodyHtml = true;

            //設定gmail的smtp (這是google的)
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("vigorhan@gmail.com", "quaawcpqasjxblxy");

            //開啟ssl
            MySmtp.EnableSsl = true;

            //發送郵件
            MySmtp.Send(mail);

            //放掉宣告出來的MySmtp
            MySmtp = null;

            //放掉宣告出來的mail
            mail.Dispose();

            return Json("cool success");
        }
    }
}
