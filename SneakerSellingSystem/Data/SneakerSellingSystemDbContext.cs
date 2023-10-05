namespace SneakerSellingSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SneakerSellingSystem.Data.Models;

    public class SneakerSellingSystemDbContext : IdentityDbContext
    {
        public SneakerSellingSystemDbContext(DbContextOptions<SneakerSellingSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sneaker> Sneakers { get; init; }

        public DbSet<Category> Categories { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Sneaker>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Sneakers)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}