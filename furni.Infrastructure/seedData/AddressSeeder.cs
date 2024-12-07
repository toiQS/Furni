using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;

namespace furni.Infrastructure.seedData
{
    public static class AddressSeeder
    {
        public static void Initialize(this IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if(context.Address.Any ()) return;
            context.Address.AddRange(
                new Address
                {
                    AppUserId = "user-1",
                    FullName = "Nguyen Van A",
                    Email = "nguyenvana@gmail.com",
                    Phone = "0123456789",
                    SpecificAddress = "RGRP+P43, Vị Thanh, Vị Thuỷ, Hậu Giang, Việt Nam",
                    IsDefault = true,
                    IsDeleted = false,
                    Orders = new List<Order>()
                }
            );
            context.SaveChanges();
        }
    }
}
