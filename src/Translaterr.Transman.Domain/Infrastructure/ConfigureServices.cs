using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Domain.Data;
using Translaterr.Transman.Domain.Services;

namespace Translaterr.Transman.Domain.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // DataContexts
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Application"));
            });

            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Cache");
            });
            
            // Services
            serviceCollection.AddScoped<ITranslationCacheManager, TranslationCacheManager>();
            serviceCollection.AddScoped<IApplicationTranslationManager, ApplicationTranslationManager>();
            
            return serviceCollection;
        }
    }
}