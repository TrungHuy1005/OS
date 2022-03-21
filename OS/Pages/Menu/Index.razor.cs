using Microsoft.AspNetCore.Components;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Menu
{
    public partial class Index:ComponentBase
    {
        private ProductViewModel productViewModel = new ProductViewModel();
        protected override async Task OnInitializedAsync()
        {

        }
    }
}
