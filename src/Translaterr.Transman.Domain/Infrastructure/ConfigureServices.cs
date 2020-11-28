using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Data.Infrastructure;
using Translaterr.Transman.Domain.Services;

namespace Translaterr.Transman.Domain.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // DataContexts
            serviceCollection.AddDataServices(configuration);
            
            // Services
            serviceCollection.AddScoped<ITranslationsService, TranslationsService>();

            return serviceCollection;
        }
    }
}