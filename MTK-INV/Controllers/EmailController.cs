using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;
using MTK_Inv.Models;
using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MTK_Delivery.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public EmailController(dataContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.email.ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Email email)
        {
            string to = "weldshprogramer25@gmail.com"; //To address    
            string from = "weldetsadik2535@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("weldetsadik2535@gmail.com", "naagncagajuicfyn");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            //var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
            //client.UseDefaultCredentials = false;
            //client.EnableSsl = true;

            //client.Credentials = new System.Net.NetworkCredential("yourusername", "yourpassword");

            //var mailMessage = new System.Net.Mail.MailMessage();
            //mailMessage.From = new System.Net.Mail.MailAddress("youremail@example.com");

            //mailMessage.To.Add(email.To);

            //if (!string.IsNullOrEmpty(email.Cc))
            //{
            //    mailMessage.CC.Add(email.Cc);
            //}

            //mailMessage.Body = email.Text;

            //mailMessage.Subject = email.Subject;

            //mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            //mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            //await client.SendMailAsync(mailMessage);

            return Ok();
        }
    }
}
