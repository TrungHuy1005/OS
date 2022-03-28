using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class Bill : ComponentBase
    {
        private InvoiceDetailViewModel invoice = new InvoiceDetailViewModel();
        [Parameter]
        public ProductViewModel productOrder { get; set; }
        [Inject]
        IOrderService IOrderService { get; set; }
        protected override void OnParametersSet()
        {
            if (productOrder == null) return;
            if (invoice.Products.Contains(productOrder)) return;
            invoice.Products.Add(productOrder);
            invoice.TotalPrice = IOrderService.GetOrder(invoice.Products);
            invoice.TotalProduct = IOrderService.GetTotalProductOrder(invoice.Products);
        }
        public void MinusQuantity(ProductViewModel product)
        {
            if (product.Quantity <=0)
            {
                invoice.Products.Remove(product);
            }
            else
            {
                product.Quantity -= 1;
            }
            invoice.TotalPrice = IOrderService.GetOrder(invoice.Products);
            invoice.TotalProduct = IOrderService.GetTotalProductOrder(invoice.Products);
        }
        public void PlusQuantity(ProductViewModel product)
        {
            product.Quantity += 1;
            invoice.TotalPrice = IOrderService.GetOrder(invoice.Products);
            invoice.TotalProduct = IOrderService.GetTotalProductOrder(invoice.Products);
        }
        public void CreateCart()
        {
            IOrderService.CreateCart(invoice);
        }    
    }
}
