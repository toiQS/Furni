using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;

namespace furni.Infrastructure.seedData
{
    public static class AddressSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Kiểm tra và thêm dữ liệu vào bảng Users
            if (!context.Users.Any(u => u.Id == "user-1"))
            {
                context.Users.Add(new AppUser
                {
                    Id = "user-1",
                    UserName = "nguyenvana",
                    Email = "nguyenvana@gmail.com",
                    // Các trường khác cần thiết cho User
                });
                context.SaveChanges();
            }

            // Thêm Address
            if (!context.Address.Any())
            {
                context.Address.Add(new Address
                {
                    AppUserId = "user-1",
                    FullName = "Nguyen Van A",
                    Email = "nguyenvana@gmail.com",
                    Phone = "0123456789",
                    SpecificAddress = "RGRP+P43, Vị Thanh, Vị Thuỷ, Hậu Giang, Việt Nam",
                    IsDefault = true,
                    IsDeleted = false,
                    Orders = new List<Order>()
                });
                context.SaveChanges();
            }
        }

    }
}
