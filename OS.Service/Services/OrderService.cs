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
    public class OrderService : BaseService , IOrderService 
    {
        public OrderService(IDbContextFactory<OnlineShopDbContext> dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {

        }
        public List<ProductViewModel> GetListProductOrder()
        {
            var context = _dbContextFactory.CreateDbContext();
            List<Product> products = context.Product.Include(t => t.Category).ToList();
            if (products is not null)
            {
                return _mapper.Map<List<ProductViewModel>>(products);
            }
            else
            {
                return null;
            }
        }
        public int GetOrder(List<ProductViewModel> productsOrder)
        {
            int total = 0;
            foreach(var item in productsOrder)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
        public int GetTotalProductOrder(List<ProductViewModel> products)
        {
            int quantity = 0;
            foreach(var item in products)
            {
                quantity += item.Quantity;

            }
            return quantity;
        }
    }
}
