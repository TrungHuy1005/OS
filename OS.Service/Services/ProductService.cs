using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using OS.Data.Context;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IDbContextFactory<OnlineShopDbContext> dbContextFactory,IMapper mapper) :base(dbContextFactory,mapper)
        {

        }
        public List<ProductViewModel> GetAllProduct()
        {
            var context = _dbContextFactory.CreateDbContext();
            List<Product> products= context.Product.Include(t=>t.Category).ToList();
            if (products is not null)
            {
                return _mapper.Map<List<ProductViewModel>>(products);
            }
            else
            {
                return null;
            }    
        }
        public async Task<bool> AddListProductFromExcelFileAsync(IBrowserFile browserFile)
        {

            return true;
        }

    }
}
