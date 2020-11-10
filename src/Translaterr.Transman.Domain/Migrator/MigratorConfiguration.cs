namespace Translaterr.Transman.Domain.Migrator
{
    public class MigratorConfiguration
    {
        public const string ConfigKey = "Migrations";
        
        public bool Enabled { get; set; }
        public bool RecreateDbOnStartup { get; set; }
    }
}