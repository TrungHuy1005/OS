using Microsoft.AspNetCore.Components;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Pages.Login
{
    public partial class Index : ComponentBase
    {
        [Inject]
        IEmailService IEmailService { get; set; }
        protected void SendEmail()
        {
        }
    }
}
