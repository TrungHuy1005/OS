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
        private ProductViewModel productOrder;
        private int isCountOrder;
        private bool isOrder;
        private List<ProductViewModel> products = new List<ProductViewModel>();
        [Inject]
        public IEmailService IEmailService { get; set; }
        [Inject]
        public IProductService IProductService { get; set; }
        [Inject]
        ISearchProductService ISearchProductService { get; set; }
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
       
        public void HandleCountOrderChanged(int isCountOrder)
        {
            this.isCountOrder = isCountOrder;
        }    
    }
}
