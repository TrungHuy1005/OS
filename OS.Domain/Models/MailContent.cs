using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Models
{
    public class MailContent
    {
        public List<string> To = new List<string>();
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
