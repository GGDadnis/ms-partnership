using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using ms_partnership.Models.Entities;

namespace ms_partnership.Service.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void sendMail(Email request)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config.GetSection("MailConfig")["EmailUser"]));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            var smtp = new SmtpClient();

            int port = 587;


            smtp.Connect(_config.GetSection("MailConfig")["Host"], port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("MailConfig")["EmailUser"], _config.GetSection("MailConfig")["EmailPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}