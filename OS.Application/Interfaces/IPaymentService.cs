using OS.Application.ViewModels;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Application.Interfaces
{
    public interface IPaymentService
    {
        string Payment();
        List<CartProductViewModel> GetAllCartByBill(Bill bill);
        List<Bill> GetAllInvoice();
    }
}
