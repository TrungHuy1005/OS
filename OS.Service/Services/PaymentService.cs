using OS.Application.Interfaces;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class PaymentService : IPaymentSerivce
    {
        public int Payment(List<ProductViewModel> products)
        {
            int total = 0;
            total += products.Select(t => t.Price).FirstOrDefault();
            return total;
        }
    }
}
