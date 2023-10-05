namespace SneakerSellingSystem.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SneakerSellingSystem.Data;
    using SneakerSellingSystem.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<SneakerSellingSystemDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(SneakerSellingSystemDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Lifestyle"},
                new Category { Name = "Leather" },
                new Category { Name = "Running" },
                new Category { Name = "Basketball" },
                new Category { Name = "Football" },
                new Category { Name = "High Top" }
            });

            data.SaveChanges();
        }
    }
}
