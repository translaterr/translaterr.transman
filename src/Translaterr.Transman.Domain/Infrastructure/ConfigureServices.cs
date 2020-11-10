using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Abstractions.Factories;
using Translaterr.Transman.Abstractions.Migrator;
using Translaterr.Transman.Abstractions.Seeder;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Domain.Data;
using Translaterr.Transman.Domain.Factories;
using Translaterr.Transman.Domain.Migrator;
using Translaterr.Transman.Domain.Seeder;
using Translaterr.Transman.Domain.Services;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Configuration
            serviceCollection.Configure<MigratorConfiguration>(configuration.GetSection(MigratorConfiguration.ConfigKey));
            serviceCollection.Configure<SeederConfiguration>(configuration.GetSection(SeederConfiguration.ConfigKey));
            
            // DataContexts
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDb"));
            });

            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "Translaterr_Transman_";
                options.Configuration = configuration.GetConnectionString("Cache");
            });
            
            // Services
            serviceCollection.AddScoped<ITranslationCacheManager, TranslationCacheManager>();
            serviceCollection.AddScoped<IApplicationTranslationManager, ApplicationTranslationManager>();
            
            // Health checks
            serviceCollection
                .AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("ApplicationDb"), name: "Database", tags: new []{"Database"})
                .AddRedis(configuration.GetConnectionString("Cache"), "Cache", tags: new []{"Database"});
            
            // Factories
            serviceCollection.AddTransient<IFactory<Tenant>, TenantFactory>();
            serviceCollection.AddTransient<IFactory<Application>, ApplicationFactory>();
            serviceCollection.AddTransient<IFactory<TranslationKey>, TranslationKeyFactory>();
            serviceCollection.AddTransient<IFactory<TranslationValue>, TranslationValueFactory>();
            
            // Seeder
            serviceCollection.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
            
            // Migrator
            serviceCollection.AddTransient<IMigrator, DatabaseMigrator>();
            
            return serviceCollection;
        }
    }
}