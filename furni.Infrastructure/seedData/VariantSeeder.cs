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
    public static class VariantSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
{
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if(context.ProductVariant.Any()) return;
            context.ProductVariant.AddRange(
                new Variant()
                {
                    ColorId = 1,
                    Position = 1,
                    ProductId = 1,
                    ThumbnailId = 1,
                });
            context.SaveChanges();
        }
    }
}
