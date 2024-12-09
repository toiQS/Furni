using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace furni.Infrastructure.SeedData
{
    public static class BrandSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Use the scoped provider to get ApplicationDbContext
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Check if any Brand exists; if not, seed data
            if (context.Brand.Any()) return;

            context.Brand.AddRange(
                new Brand()
                {
                    Name = "Canifa",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "New Fashion",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "IVY Moda",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "Format",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "Routine",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "K&K Fashion",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "Libé",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "BOO ",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand()
                {
                    Name = "Hnoss Fashion",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Brand { Name = "Adidas", IsDeleted = false, Products = new List<Product>() }
            );

            // Apply migrations and save changes
            //context.Database.Migrate();
            context.SaveChanges();
        }

    }
}
