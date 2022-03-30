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
        [Parameter]
        public bool IsOrder { get; set; }
        [Parameter]
        public EventCallback<bool> HandleOrderProduct { get; set; }
        [Parameter]
        public ProductViewModel productOrder { get; set; }
        [Parameter]
        public int isCountOrder { get; set; }
        private int count = 0;
        protected override void OnInitialized()
        {
            IsOrder = false;
        }
        protected override void OnParametersSet()
        {
            count = isCountOrder;
        }
        protected async Task HandleOrder()
        {
            IsOrder = !IsOrder;
            await HandleOrderProduct.InvokeAsync(IsOrder);
        }
    }
}
