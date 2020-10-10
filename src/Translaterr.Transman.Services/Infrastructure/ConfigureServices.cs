using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Services.Services;

namespace Translaterr.Transman.Services.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddTransmanServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Services
            serviceCollection.AddScoped<ITenantsService, TenantsService>();
            
            return serviceCollection;
        }
    }
}