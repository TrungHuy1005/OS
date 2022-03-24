using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Application.Interfaces
{
    public interface IOrderService
    {
        List<ProductViewModel> GetListProductOrder();
        int GetOrder(InvoiceDetailViewModel invoice);
        int GetTotalProductOrder(List<ProductViewModel> products);
    }
}
