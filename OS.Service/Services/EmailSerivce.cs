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
    public class EmailSerivce : IEmailService
    {
        private readonly Domain.Models.MailSettings mailSettings;
        public EmailSerivce(IOptions<Domain.Models.MailSettings> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }
        public string SendEmail(MailContent mailContent)
        {
            if (mailContent.To == null)
            {
                return "Email To Address Empty";
            }
            SmtpClient smtpClient = new SmtpClient(mailSettings.Host, mailSettings.Port);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(mailSettings.Mail,mailSettings.Password,mailSettings.Host);
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(mailSettings.Mail);
                message.Priority = MailPriority.High;
                message.Subject = mailContent.Subject == null ? "" : mailContent.Subject;
                message.Body = mailContent.Body == null ? "" : mailContent.Body;
                message.IsBodyHtml = true;
                foreach (string email in mailContent.To)
                {
                    message.To.Add(email);
                }
                /*try
                {*/
                    smtpClient.Send(message);
                    return "Email Send SuccessFully";
               /* }
                catch
                {
                    return "Email Send failed";
                }*/
            }
        }

    }
}
