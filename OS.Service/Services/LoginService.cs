using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces;
using OS.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class LoginService : BaseService,ILoginService
    {
        public LoginService(IDbContextFactory<OnlineShopDbContext> dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {

        }

    }
}
