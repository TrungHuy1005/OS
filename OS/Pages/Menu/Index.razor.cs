using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class Index:ComponentBase
    {
        private ProductViewModel productViewModel = new ProductViewModel();
        [Inject]
        public IEmailService IEmailService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
        }
        public void SendMail()
        {
            MailContent content = new MailContent
            {
                Subject = "Kiểm tra thử",
                Body = "<p><strong>Xin chào xuanthulab.net</strong></p>"
            };
            content.To.Add("trunghuy0501@gmail.com");
            string num = IEmailService.SendEmail(content);
        }
    }
}
