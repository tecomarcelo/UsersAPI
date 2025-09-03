using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Application.Services;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.Services;
using UsersAPI.Infra.Data.Contexts;
using UsersAPI.Infra.Data.Repositories;

namespace UsersAPI.Infra.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IAuthAppService, AuthAppService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DataContext>();

            return services;
        }
    }
}
