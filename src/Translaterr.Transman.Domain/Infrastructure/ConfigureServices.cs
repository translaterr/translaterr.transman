using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Domain.Data;

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
            
            return serviceCollection;
        }
    }
}