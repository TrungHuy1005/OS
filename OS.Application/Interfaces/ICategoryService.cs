using OS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Application.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAllCategories();
    }
}
