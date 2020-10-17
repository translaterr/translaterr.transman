using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasMany(t => t.Applications)
                .WithOne(a => a.Tenant)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tenant>()
                .HasIndex(t => new {t.PublicId})
                .IsUnique();

            modelBuilder.Entity<Tenant>()
                .HasIndex(t => new {t.Name})
                .IsUnique();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.Translations)
                .WithOne(t => t.Application)
                .HasForeignKey(t => t.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasIndex(a => new {a.Name, a.TenantId})
                .IsUnique();

            modelBuilder.Entity<Translation>()
                .HasIndex(t => new {t.ApplicationId, t.LanguageCode})
                .IsUnique();
            modelBuilder.Entity<Translation>()
                .HasIndex(t => new {t.ApplicationId, t.LanguageCode, t.EnvironmentId, t.Key})
                .IsUnique();
            modelBuilder.Entity<Translation>()
                .HasIndex(t => new {t.PublicId});
        }
    }
}