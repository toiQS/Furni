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
    public static class VariantSizeSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.VariantSize.AddRange(
                new VariantSize { IsActive = true, SizeId = 1, Quantity =10, VariantId = 1},
                new VariantSize { IsActive = true, SizeId = 2, Quantity =10, VariantId = 1},
                new VariantSize { IsActive = true, SizeId = 3, Quantity =10, VariantId = 1},
                new VariantSize { IsActive = true, SizeId = 4, Quantity =10, VariantId = 1}
            );
            context.SaveChanges();
        }
    }
}
