using BlazorAnimate;
using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class ListProduct : ComponentBase
    {
        private Animate animate;
        [Parameter]
        public bool IsOrder { get; set; }
        [Parameter]
        public ProductViewModel product { get; set; }
        [Parameter]
        public EventCallback<bool> HandleOrderProduct { get; set; }
        [Inject]
        IProductService IProductService { get; set; }
        [Parameter]
        public List<ProductViewModel> products { get;set; } = new List<ProductViewModel>();
        [Parameter]
        public EventCallback<ProductViewModel> HandleOrderProductToBill { get; set; }
        protected override void OnInitialized()
        {
            IsOrder = false;
            products = IProductService.GetAllProduct();
        }
        protected async Task HandleOrder()
        {
            IsOrder = !IsOrder;
            await HandleOrderProduct.InvokeAsync(IsOrder);
        }
        protected async Task OrderProduct(ProductViewModel product)
        {
            this.product = product;
            this.product.Quantity = 1;
            await HandleOrderProductToBill.InvokeAsync(this.product);
            animate.Run();
        }
    }
}
