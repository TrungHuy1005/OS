using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class Search : ComponentBase
    {
        private string searchName;
        [Inject]
        ISearchProductService ISearchProductService { get; set; }
        [Inject]
        IProductService IProductService { get; set; }
        [Parameter]
        public List<ProductViewModel> products { get; set; }
        [Parameter]
        public EventCallback<List<ProductViewModel>> HandleSearchProduct { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (searchName == null)
            {
                products = IProductService.GetAllProduct();
            }
            else
            {
                products = ISearchProductService.GetSearchAllProduct(searchName);
            }
            await HandleSearchProduct.InvokeAsync(products);
        }
    }
}
