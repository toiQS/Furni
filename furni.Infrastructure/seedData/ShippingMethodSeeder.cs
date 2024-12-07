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
    public static class ShippingMethodSeeder
    {
        public static void Initialize(this IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if(context.ShippingMethod.Any()) return;
            context.ShippingMethod.AddRange(
                new ShippingMethod { IsDeleted= false, Cost = 10.5, Description = "", Name = ""},
                new ShippingMethod { IsDeleted= false, Cost = 12, Description = "", Name = ""}
                );
        }

    }
}
