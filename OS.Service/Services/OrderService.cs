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
        public int GetOrder(InvoiceDetailViewModel invoice)
        {
            invoice.TotalPrice = 0;
            invoice.TotalPrice += (invoice.Products.Select(t => t.Price).FirstOrDefault()) * (invoice.Products.Select(h => h.Quantity).FirstOrDefault());
            return invoice.TotalPrice;
        }
        public int GetTotalProductOrder(List<ProductViewModel> products)
        {
            int quantity = 0;
            quantity += products.Select(t => t.Quantity).FirstOrDefault();
            return quantity;
        }
    }
}
