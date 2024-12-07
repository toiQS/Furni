using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Infrastructure.seedData
{
    public static class ColorSeed
    {
        public static void Initialize(this IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Color.Any()) return;
            context.Color.AddRange(
                new Color
                {
                    Name = "Red",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Name = "Blue",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Name = "Black",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Name = "While",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                },
                new Color
                {
                    Name = "Green",
                    IsDeleted = false,
                    ProductVariants = new List<Variant>()
                });
        }

        
    }
}
