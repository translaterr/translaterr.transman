using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Data.Entities;

namespace Translaterr.Transman.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<LanguageEntity> Languages { get; set; }
        
        public DbSet<TenantEntity> Tenants { get; set; }
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<TranslationEntity> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantEntity>()
                .HasMany(t => t.Applications)
                .WithOne(a => a.Tenant)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationEntity>()
                .HasMany(a => a.Translations)
                .WithOne(t => t.Application)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ApplicationEntity>()
                .HasOne(a => a.DefaultLanguage)
                .WithMany(l => l.DefaultApplications)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationLanguageEntity>()
                .HasKey(al => new {al.ApplicationId, al.LanguageId});
            modelBuilder.Entity<ApplicationLanguageEntity>()
                .HasOne(al => al.Application)
                .WithMany(a => a.ApplicationLanguages)
                .HasForeignKey(al => al.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationLanguageEntity>()
                .HasOne(al => al.Language)
                .WithMany(l => l.ApplicationLanguages)
                .HasForeignKey(al => al.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LanguageEntity>()
                .HasMany(l => l.Translations)
                .WithOne(t => t.Language)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}