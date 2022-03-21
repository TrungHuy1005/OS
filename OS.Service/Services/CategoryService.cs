using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces;
using OS.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OS.Application.ViewModels;
using System.Threading.Tasks;
using OS.Domain.Models;

namespace OS.Service.Services
{
    public class CategoryService:BaseService,ICategoryService
    {
        public CategoryService(IDbContextFactory<OnlineShopDbContext> dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {

        }
        public List<CategoryViewModel> GetAllCategories()
        {
            var context = _dbContextFactory.CreateDbContext();
            List<Category> categories = context.Category.ToList();
            if (categories is not null)
            {
                return _mapper.Map<List<CategoryViewModel>>(categories);
            }
            else
            {
                return null;
            }
        }

    }
}
