using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Application.ViewModels
{
    public class InvoiceDetailViewModel
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public int TotalPrice { get; set; }
    }
}
