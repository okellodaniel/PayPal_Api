using APIWrapper.Client;
using Microsoft.Extensions.DependencyInjection;

namespace APIWrapper.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApiWrapper(this IServiceCollection services)
        {
            services.AddScoped<IPayPalClient, PayPalClient>();

            return services;
        }
    }
}