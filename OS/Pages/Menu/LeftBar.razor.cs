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
        private List<ProductViewModel> products = new List<ProductViewModel>();
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
        protected void HandleProductByCategory(CategoryViewModel category)
        {
            products = (IProductService.GetAllProduct().Where(t=>t.CategoryId==category.Id)).ToList();
        }
    }
}
