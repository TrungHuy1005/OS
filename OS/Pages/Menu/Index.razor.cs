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
    public partial class Index:ComponentBase
    {
        private string searchValue;
        private ProductViewModel productOrder;
        private bool isOrder;
        private List<ProductViewModel> products = new List<ProductViewModel>();
        [Inject]
        public IEmailService IEmailService { get; set; }
        [Inject]
        public IProductService IProductService { get; set; }
        [Inject]
        ISearchProductService ISearchProductService { get; set; }
        protected override void OnParametersSet()
        {
            if (searchValue == null)
            {
                products = IProductService.GetAllProduct();
            } 
            else
            {
                products = ISearchProductService.GetSearchAllProduct(searchValue);
            }
        }
        public void HandleOrderProduct(bool isOrder)
        {
            this.isOrder = isOrder;
        }
        public void HandleGetAllProduct(List<ProductViewModel> products)
        {
            this.products = products;
        }
        public void HandleOrderProductToBill(ProductViewModel productOrder)
        {
            this.productOrder = productOrder;
        }
        private void OnSearchValueChanged(string keyword)
        {
            searchValue = keyword;
            OnParametersSet();
        }
    }
}
