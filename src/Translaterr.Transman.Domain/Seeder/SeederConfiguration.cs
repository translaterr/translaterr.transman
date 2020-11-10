namespace Translaterr.Transman.Domain.Seeder
{
    public class SeederConfiguration
    {
        public const string ConfigKey = "Seeder";
        
        public bool Enabled { get; set; }
        public int Seed { get; set; }
        public int Tenants { get; set; }
        public int ApplicationsPerTenant { get; set; }
        public int TranslationKeysPerApp { get; set; }
        public int TranslationValesPerKey { get; set; }
    }
}