using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<TranslationKey> TranslationKeys { get; set; }
        public DbSet<TranslationValue> TranslationValues { get; set; }

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
                .HasMany(a => a.TranslationKeys)
                .WithOne(t => t.Application)
                .HasForeignKey(t => t.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasIndex(a => new {a.Name, a.TenantId})
                .IsUnique();

            modelBuilder.Entity<TranslationKey>()
                .HasIndex(t => new {t.ApplicationId, t.Key})
                .IsUnique();
            modelBuilder.Entity<TranslationKey>()
                .HasIndex(t => new {t.PublicId});

            modelBuilder.Entity<TranslationKey>()
                .HasMany(tk => tk.TranslationValues)
                .WithOne(tv => tv.TranslationKey)
                .HasForeignKey(tv => tv.TranslationKeyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TranslationValue>()
                .HasKey(tk => new {tk.TranslationKeyId, tk.LanguageCode});
        }
    }
}