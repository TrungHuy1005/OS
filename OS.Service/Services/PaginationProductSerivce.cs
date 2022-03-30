using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using OS.Data.Context;
using OS.Domain.Models;
using OS.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class PaginationProductSerivce : BaseService , IPaginationProductSerivce
    {
        public PaginationProductSerivce(IDbContextFactory<OnlineShopDbContext> dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {

        }
        public async Task<PageList<ProductViewModel>> GetProducts(ProductParameters productParameters)
        {
            var context = _dbContextFactory.CreateDbContext();
            var products = context.Product.ToList();
            return PageList<ProductViewModel>
                .ToPagedList(_mapper.Map<List<ProductViewModel>>(products), productParameters.PageNumber, productParameters.PageSize);
        }
    }
}
