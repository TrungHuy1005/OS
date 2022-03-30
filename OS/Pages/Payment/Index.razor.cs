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
        private InformationCustomerViewModel customer = new InformationCustomerViewModel();
        private bool isPaymentWithMomo = false;
        private string url;
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
            string table = "<table class='custom-table m-0 table-info table-striped' border='1'><thead><tr><th>Đồ uống</th><th>Số lượng</th><th>Tổng</th></thead><tbody>";
            string endTable = "</tbody></table>";
            string body = "";
            string total = "<hr/>Tổng tiền thanh toán: " + bills[bills.Count - 1].Total.ToString();
            foreach(var item in carts)
            {
                body += "<tr><td>" + products.Where(t => t.Id == item.ProductId).Select(t => t.Name).FirstOrDefault() + "</td><td>" + item.Quantity + "</td><td>" + products.Where(t => t.Id == item.ProductId).Select(t => t.Price).FirstOrDefault()*item.Quantity + "</td></tr>";
            }
            MailContent content = new MailContent
            {
                To = customer.Email,
                Subject = "Hóa đơn",
                Body = table + body + endTable + total
            };
            string num = IEmailService.SendEmail(content);
            url = IPaymentService.Payment(bills[bills.Count - 1],carts,products);
        }
        public async Task EmailValueChanged(ChangeEventArgs e)
        {
            customer.Email = e.Value.ToString();
        }
        public void PaymentWithMomo(ChangeEventArgs e)
        {
            if(e.Value.ToString()=="on")
            {
                isPaymentWithMomo = true;
            }    
        }    
    }
}
