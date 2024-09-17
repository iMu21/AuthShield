using AuthShield.Application.Contracts.Infrastructure;
using AuthShield.Application.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            services.AddHttpClient<IProductClient, ProductClientService>(client =>
            {
                string address = configuration.GetValue<string>("ApiClient:ProductClient") ?? string.Empty;
                client.BaseAddress = new Uri(address);
            });

            services.AddHttpClient<IUserClient, UserClientService>(client =>
            {
                string address = configuration.GetValue<string>("ApiClient:UserClient") ?? string.Empty;
                client.BaseAddress = new Uri(address);
            });

            return services;
        }
    }
}
