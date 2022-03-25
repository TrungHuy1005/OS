using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class LeftBar : ComponentBase
    {
        private List<CategoryViewModel> categories = new List<CategoryViewModel>();
        [Parameter]
        public List<ProductViewModel> products { get; set; }
        [Parameter]
        public EventCallback<List<ProductViewModel>> HandleGetAllProduct { get; set; }
        [Inject]
        public ICategoryService ICategoryService { get; set; }
        [Inject]
        public IProductService IProductService { get; set; }
        private bool collapseNavMenu = true;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
        protected override void OnInitialized()
        {
            categories = ICategoryService.GetAllCategories();
        }
        protected async Task GetAllProduct()
        {
            products = IProductService.GetAllProduct();
            await HandleGetAllProduct.InvokeAsync(products);
        }
        protected async Task GetAllProductByCategory(int id)
        {
            products = IProductService.GetAllProductByCategory(id);
            await HandleGetAllProduct.InvokeAsync(products);
        }
    }
}
