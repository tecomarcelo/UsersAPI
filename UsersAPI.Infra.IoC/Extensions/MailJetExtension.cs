using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.IoC.Extensions
{
    public static class MailJetExtension
    {
        public static IServiceCollection AddMailJet(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailJetSettings>(configuration.GetSection("MailJetSettings"));
            services.AddSingleton<EmailMessageService>();

            return services;
        }
    }
}
