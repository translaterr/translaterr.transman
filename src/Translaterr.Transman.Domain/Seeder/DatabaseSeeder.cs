using System;
using System.Data.Common;
using Bogus;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Translaterr.Transman.Abstractions.Factories;
using Translaterr.Transman.Abstractions.Seeder;
using Translaterr.Transman.Domain.Data;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Seeder
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly SeederConfiguration _seederConfiguration;

        private readonly IFactory<Tenant> _tenantFactory;
        private readonly IFactory<Application> _applicationFactory;
        private readonly IFactory<TranslationKey> _translationKeyFactory;
        private readonly IFactory<TranslationValue> _translationValueFactory;

        public DatabaseSeeder(ILogger<DatabaseSeeder> logger, AppDbContext appDbContext, IOptions<SeederConfiguration> seederConfiguration, IFactory<Tenant> tenantFactory, IFactory<Application> applicationFactory, IFactory<TranslationKey> translationKeyFactory, IFactory<TranslationValue> translationValueFactory)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _seederConfiguration = seederConfiguration.Value;
            _tenantFactory = tenantFactory;
            _applicationFactory = applicationFactory;
            _translationKeyFactory = translationKeyFactory;
            _translationValueFactory = translationValueFactory;
        }

        public void SeedDatabase()
        {
            if (_seederConfiguration.Enabled is false)
            {
                _logger.LogInformation("Seeder disabled, skipping seeding the database");
                return; 
            }

            _logger.LogInformation("Database seeder is enabled");
            _logger.LogInformation("Using database seed of {seed}", _seederConfiguration.Seed.ToString());
            Randomizer.Seed = new Random(_seederConfiguration.Seed);
            
            _logger.LogInformation("Starting to generate random data");

            var tenants = _tenantFactory.Generate(_seederConfiguration.Tenants);
            _appDbContext.Tenants.AddRange(tenants);

            foreach (var tenant in tenants)
            {
                var applications = _applicationFactory.Generate(_seederConfiguration.ApplicationsPerTenant);
                _appDbContext.Applications.AddRange(applications);

                foreach (var application in applications)
                {
                    application.Tenant = tenant;
                    var translationKeys = _translationKeyFactory.Generate(_seederConfiguration.TranslationKeysPerApp);
                    
                    _appDbContext.TranslationKeys.AddRange(translationKeys);

                    foreach (var translationKey in translationKeys)
                    {
                        translationKey.Application = application;
                        var translationValues = _translationValueFactory.Generate(_seederConfiguration.TranslationValesPerKey);
                        
                        _appDbContext.TranslationValues.AddRange(translationValues);

                        foreach (var translationValue in translationValues)
                        {
                            translationValue.TranslationKey = translationKey;
                        }
                    }
                }
            }
            
            _logger.LogInformation("Data generated. Starting saving data to the database");

            try
            {
                _appDbContext.SaveChanges();
            }
            catch(DbException dbException)
            {
                _logger.LogError(dbException, "An error occurred during saving the data to the database. Seeder was unable to complete.");
                return;
            }
            
            _logger.LogInformation("Seeding completed");
        }
    }
}