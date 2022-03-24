using Microsoft.AspNetCore.Components;
using OS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Payment
{
    public partial class Index : ComponentBase
    {
        [Inject]
        IPaymentService IPaymentService { get; set; }
        public string PaymentMomo()
        {
            return IPaymentService.Payment();
        }    
    }
}
