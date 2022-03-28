using AutoMapper;
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
    public class SearchProductService : BaseService, ISearchProductService
    {
        public SearchProductService(IDbContextFactory<OnlineShopDbContext> dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {

        }
        public List<ProductViewModel> GetSearchAllProduct(string name)
        {
            var context = _dbContextFactory.CreateDbContext();
            var products = context.Product.Where(t => t.Name.ToLower().Contains(name.ToLower())).ToList();
            if(products is null)
            {
                return null;
            }    
            return _mapper.Map<List<ProductViewModel>>(products);
        }
    }
}
