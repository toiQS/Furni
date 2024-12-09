using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace furni.Infrastructure.seedData
{
    public static class CategorySeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Category.Any()) return;

            context.Category.AddRange(
                new Category()
                {
                    Name = "Nón",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Name = "Áo",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Name = "Quần",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Name = "Giày",
                    IsDeleted = false,
                    Products = new List<Product>()
                },
                new Category()
                {
                    Name = "Phụ kiện",
                    IsDeleted = false,
                    Products = new List<Product>()
                }
            );

            context.SaveChanges();
        }


    }
}
