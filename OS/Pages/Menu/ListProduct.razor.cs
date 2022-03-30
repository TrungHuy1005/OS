using BlazorAnimate;
using Blazored.Modal;
using Blazored.Modal.Services;
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
    public partial class ListProduct : ComponentBase
    {
        private ProductParameters productParameters = new ProductParameters();
        private int pageCurrent;
        [Parameter]
        public ProductViewModel product { get; set; }
        [Inject]
        IProductService IProductService { get; set; }
        [Parameter]
        public List<ProductViewModel> products { get;set; } = new List<ProductViewModel>();
        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Parameter]
        public EventCallback<ProductViewModel> HandleOrderProductToBill { get; set; }
        [Inject]
        IPaginationProductSerivce IPaginationProductSerivce { get; set; }
       
        protected override void OnInitialized()
        {
            pageCurrent = 1;
        }
        protected override void OnParametersSet()
        {
            productParameters.PageNumber = pageCurrent;
            productParameters.PageSize = 6;
            products = IPaginationProductSerivce.GetProducts(productParameters).Result;
        }
        protected async Task OrderProduct(ProductViewModel product)
        {
            this.product = product;
            this.product.Quantity = 1;
            await HandleOrderProductToBill.InvokeAsync(this.product);
        }
        public void HandleProductValueChangedLeft()
        {
            if (pageCurrent > 1)
            {
                pageCurrent--;
            }
            OnParametersSet();
        }
        public void HandleProductValueChangedRight()
        {
            if (pageCurrent < 4)
            {
                pageCurrent++;
            }
            OnParametersSet();
        }
    }
}
