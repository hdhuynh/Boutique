using System;
using System.Configuration;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace BoutiqueEstate.Controllers
{
    public class SendMailerController : Controller
    {
        //
        // GET: /SendMailer/ 

        [HttpPost]
        public ViewResult Index(string from, string to, string subject, string body )
        {
            if (String.IsNullOrEmpty(from)) return View("Error");
            if (String.IsNullOrEmpty(to)) return View("Error");
            if (String.IsNullOrEmpty(subject) && String.IsNullOrEmpty(body)) return View("Error");
      
            
            var mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailUsername"], ConfigurationManager.AppSettings["EmailPassword"]),
                EnableSsl = true
            };
            smtp.Send(mail);
            return View("Error");
            
          
        }
    }
}