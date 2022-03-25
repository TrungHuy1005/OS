﻿using Microsoft.AspNetCore.Components;
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
        private bool isOrder;
        private List<ProductViewModel> products = new List<ProductViewModel>();
        [Inject]
        public IEmailService IEmailService { get; set; }
        protected override async Task OnInitializedAsync()
        {
        }
        public void SendMail()
        {
            MailContent content = new MailContent
            {
                To= "trunghuy0501@gmail.com",
                Subject = "Kiểm tra thử",
                Body = "<p><strong>Xin chào xuanthulab.net</strong></p>"
            };
            string num = IEmailService.SendEmail(content);
        }
        public void HandleOrderProduct(bool isOrder)
        {
            this.isOrder = isOrder;
        }
        public void HandleGetAllProduct(List<ProductViewModel> products)
        {
            this.products = products;
        }
    }
}
