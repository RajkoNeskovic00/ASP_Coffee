using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Email
{
   
    public class SenderEmail : IEmail
    {
        private readonly string _fromEmail;
        private readonly string _emailPassword;

        public SenderEmail(string fromEmail, string emailPassword)
        {
            _fromEmail = fromEmail;
            _emailPassword = emailPassword;
        }

        public void Send(EmailSendDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, _emailPassword)
            };

            var message = new MailMessage(_fromEmail, dto.SentTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
