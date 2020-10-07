using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Translaterr.Transman.Data.Contexts;

namespace Translaterr.Transman.Data.Infrastructure
{
    public static class ConfigureDataServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Application"));
            });

            return serviceCollection;
        }
    }
}