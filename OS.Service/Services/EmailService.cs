using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using OS.Domain.Models;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly Domain.Models.MailSettings mailSettings;
        public EmailService(IOptions<Domain.Models.MailSettings> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }
        public string SendEmail(MailContent mailContent)
        {
            if (mailContent.To == null)
            {
                return "Email To Address Empty";
            }
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailSettings.Mail);
                mail.To.Add(mailContent.To);
                mail.Subject = mailContent.Subject;
                mail.IsBodyHtml = true;
                mail.Body = mailContent.Body;
                SmtpClient SmtpServer = new SmtpClient(mailSettings.Host);
                mail.Priority = MailPriority.High;
                SmtpServer.Port = mailSettings.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailSettings.Mail.Trim(), mailSettings.Password.Trim());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
