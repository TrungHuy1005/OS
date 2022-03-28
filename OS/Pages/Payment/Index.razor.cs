using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Payment
{
    public partial class Index : ComponentBase
    {
        private List<CartProductViewModel> carts = new List<CartProductViewModel>();
        private List<Bill> bills = new List<Bill>();
        private List<ProductViewModel> products = new List<ProductViewModel>();
        [Inject]
        IEmailService IEmailService { get; set; }
        [Inject]
        IPaymentService IPaymentService { get; set; }
        [Inject]
        IProductService IProductService { get; set; }
        protected override void OnInitialized()
        {
            products = IProductService.GetAllProduct();
            bills = IPaymentService.GetAllInvoice();
            carts = IPaymentService.GetAllCartByBill(bills[bills.Count-1]);
        }
        public void SendMail()
        {
            MailContent content = new MailContent
            {
                To = "trunghuy0501@gmail.com",
                Subject = "Kiểm tra thử",
                Body = "<p><strong>Xin chào xuanthulab.net</strong></p>"
            };
            string num = IEmailService.SendEmail(content);
        }
    }
}
