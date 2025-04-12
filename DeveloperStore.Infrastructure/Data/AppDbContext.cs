using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(s => s.Id);
            modelBuilder.Entity<SaleItem>().HasKey(i => i.Id);

            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
