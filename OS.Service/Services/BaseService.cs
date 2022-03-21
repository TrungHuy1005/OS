using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nest;
using OS.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class BaseService
    {
        protected readonly IDbContextFactory<OnlineShopDbContext> _dbContextFactory;
        protected readonly IMapper _mapper;

        public BaseService(IDbContextFactory<OnlineShopDbContext> dbContextFactory,IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }
    }
}
