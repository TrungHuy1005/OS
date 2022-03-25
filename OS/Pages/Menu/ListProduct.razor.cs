using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class ListProduct : ComponentBase
    {
        [Parameter]
        public bool IsOrder { get; set; }
        [Parameter]
        public EventCallback<bool> HandleOrderProduct { get; set; }
        protected override void OnInitialized()
        {
            IsOrder = false;
        }
        protected async Task HandleOrder()
        {
            IsOrder = !IsOrder;
            await HandleOrderProduct.InvokeAsync(IsOrder);
        }
    }
}
