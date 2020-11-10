
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Translaterr.Transman.Abstractions.Migrator;
using Translaterr.Transman.Domain.Data;

namespace Translaterr.Transman.Domain.Migrator
{
    public class DatabaseMigrator : IMigrator
    {
        private readonly ILogger<DatabaseMigrator> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly MigratorConfiguration _migratorConfiguration;

        public DatabaseMigrator(ILogger<DatabaseMigrator> logger, AppDbContext appDbContext, IOptions<MigratorConfiguration> migratorConfiguration)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _migratorConfiguration = migratorConfiguration.Value;
        }
        
        public void HandleMigrations()
        {
            if (_migratorConfiguration.RecreateDbOnStartup)
            {
                DeleteAndRecreateDatabase();
            }

            if (_migratorConfiguration.Enabled)
            {
                MigrateDatabase();
            }
        }
        
        public void DeleteAndRecreateDatabase()
        {
            _logger.LogInformation("Deleting database");
            _appDbContext.Database.EnsureDeleted();
            
            _logger.LogInformation("Recreating database");
            _appDbContext.Database.EnsureCreated();
        }

        public void MigrateDatabase()
        {
            _logger.LogInformation("Starting migrations");
            _appDbContext.Database.Migrate();
            _logger.LogInformation("Migrations complete");
        }
    }
}