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
        public ProductViewModel product { get; set; }
        [Inject]
        IOrderService IOrderService { get; set; }
        protected override async Task OnInitializedAsync()
        {
/*            invoice.Products.Add(product);
*//*            invoice.TotalPrice = IOrderService.GetOrder(invoice);
*/        }
    }
}
