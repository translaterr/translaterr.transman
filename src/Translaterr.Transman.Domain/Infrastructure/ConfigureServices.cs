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

            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "Translaterr_Transman_";
                options.Configuration = configuration.GetConnectionString("Cache");
            });
            
            // Services
            serviceCollection.AddScoped<ITranslationsService, TranslationsService>();
            serviceCollection.AddScoped<ITranslationCacheManager, TranslationCacheManager>();
            
            // Health checks
            serviceCollection
                .AddHealthChecks()
                .AddRedis(configuration.GetConnectionString("Cache"), "Cache", tags: new []{"Database"});

            return serviceCollection;
        }
    }
}