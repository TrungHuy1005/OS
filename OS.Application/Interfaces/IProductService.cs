using Microsoft.AspNetCore.Components.Forms;
using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Application.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProduct();
        Task<bool> AddListProductFromExcelFileAsync(IBrowserFile browserFile);
    }
}
