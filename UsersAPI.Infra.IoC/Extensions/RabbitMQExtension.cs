using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.Interfaces.Messages;
using UsersAPI.Infra.Messages.Consumers;
using UsersAPI.Infra.Messages.Producers;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.IoC.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));
            services.AddTransient<IUserMessageProducer, UserMessageProducer>();
            services.AddHostedService<UserMessageConsumer>();

            return services;
        }

    }
}
