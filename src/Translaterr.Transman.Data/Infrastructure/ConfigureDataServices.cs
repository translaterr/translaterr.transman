using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Abstractions.Data;
using Translaterr.Transman.Abstractions.Repositories;
using Translaterr.Transman.Data.Contexts;
using Translaterr.Transman.Data.Data;
using Translaterr.Transman.Data.Repositories;

namespace Translaterr.Transman.Data.Infrastructure
{
    public static class ConfigureDataServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, IConfiguration config)
        {
            // Db context
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Application"));
            });
            
            // Repositories
            serviceCollection.AddScoped<ITenantsRepository, TenantsRepository>();
            
            // Unit of Work
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}