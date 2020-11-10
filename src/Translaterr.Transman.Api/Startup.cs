using System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Translaterr.Transman.Abstractions.Migrator;
using Translaterr.Transman.Abstractions.Seeder;
using Translaterr.Transman.Domain.Infrastructure;
using Translaterr.Transman.Domain.Seeder;

namespace Translaterr.Transman.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            
            services.AddDataServices(Configuration);
            
            services.AddControllers();
            
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseSeeder databaseSeeder, IMigrator migrator)
        {
            migrator.HandleMigrations();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                databaseSeeder.SeedDatabase();
            }

            app.UseHttpsRedirection();
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = String.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Translaterr.Transman.Api");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                
                endpoints.MapControllers();
            });
        }
    }
}