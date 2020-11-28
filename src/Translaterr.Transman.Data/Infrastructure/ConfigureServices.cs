using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Translaterr.Transman.Abstractions.Repositories;
using Translaterr.Transman.Data.Repositories;

namespace Translaterr.Transman.Data.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Database clients
            serviceCollection.AddSingleton<MongoClient>(new MongoClient(configuration.GetConnectionString("TranslationsDb")));

            // Repositories
            serviceCollection.AddScoped<ITranslationsRepository, TranslationsRepository>();
            
            return serviceCollection;
        }
    }
}