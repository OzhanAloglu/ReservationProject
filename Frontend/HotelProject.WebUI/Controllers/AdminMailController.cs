using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {

            //Mail gönderme işlemi yapılıyor.

            MimeMessage mimeMessage= new MimeMessage();

            //Kİmden olacağı
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Otel Rezervasyon İşlemleri", "kursprojeozhan@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            //Kİme olacağı
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //Mesajın içeriği
            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject=adminMailViewModel.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("kursprojeozhan@gmail.com", "crxblyvxaebfmwao");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);



            return View();
        }
    }
}
