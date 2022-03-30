using OS.Application.ViewModels;
using OS.Domain.Models;
using OS.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Application.Interfaces
{
    public interface IPaginationProductSerivce
    {
        Task<PageList<ProductViewModel>> GetProducts(ProductParameters productParameters);
    }
}
