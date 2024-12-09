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
    public static class ProductSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Product.Any()) return;


            context.Product.AddRange(
            #region category
            // giày
            #region brand
            // addidas
            new Product { BrandId = 10, Name = "Giày Adizero EVO SL", CategoryId = 4, Description = "", CreatedAt = DateTime.Now, IsDeleted = false, Price = 10, PriceSale = 20, Thumbnail = new Image { Name = "" }, Slug = "", Label = Label.Hot, IsFeatured = true, Status = Status.Published }
            //new Product { BrandId = 10, Name }

            #endregion
            #endregion
            );
            context.SaveChanges();
        }

    }
}
