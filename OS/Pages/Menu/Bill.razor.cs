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
        [Parameter]
        public int isCountOrder { get; set; } = 0;
        [Inject]
        IOrderService IOrderService { get; set; }
        [Parameter]
        public EventCallback<int> HandleCountOrderChanged { get; set; }
        protected override void OnParametersSet()
        {
            if (productOrder == null)
            {
                return;
            }
            foreach (var item in invoice.Products)
            {
                if(item.Name.Contains(productOrder.Name))
                {
                    return;
                }
            }    
            invoice.Products.Add(productOrder);
            isCountOrder = invoice.Products.Count;
            HandleCountOrderChanged.InvokeAsync(isCountOrder);
            invoice.TotalPrice = IOrderService.GetOrder(invoice.Products);
            invoice.TotalProduct = IOrderService.GetTotalProductOrder(invoice.Products);
        }
        public void MinusQuantity(ProductViewModel product)
        {
            if (product.Quantity <= 0)
            {
                invoice.Products.Remove(product);
                isCountOrder = invoice.Products.Count;
                HandleCountOrderChanged.InvokeAsync(isCountOrder);
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
        public void QuantityValueChanged(ChangeEventArgs e,ProductViewModel product)
        {
            foreach(var item in invoice.Products)
            {
                if(item.Name==product.Name)
                {
                    if (e.Value.ToString().Length == 0) return;
                    item.Quantity = Convert.ToInt32(e.Value.ToString());
                }
                invoice.TotalPrice = IOrderService.GetOrder(invoice.Products);
                invoice.TotalProduct = IOrderService.GetTotalProductOrder(invoice.Products);
            }    
        }
    }
}
