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
        public EventCallback<string> OnSearchValueChanged { get; set; }
        private async Task OnValueChangeAsync(ChangeEventArgs e)
        {
            await OnSearchValueChanged.InvokeAsync(e.Value.ToString());
        }
    }
}
