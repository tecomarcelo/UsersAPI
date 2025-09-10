using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.IoC.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //capiturando o parametro DataBaseProvider
            var dataBaseProvider = configuration.GetSection("DataBaseProvider").Value;

            //verificando o tipo de provider de banco de dados
            switch (dataBaseProvider)
            {
                case "SqlServer":
                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("BdUsersAPI"));
                    });
                    break;

                case "InMemory":
                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseInMemoryDatabase(databaseName: "BdUsersAPI");
                    });
                    break;
            }

            return services;
        }
    }
}
