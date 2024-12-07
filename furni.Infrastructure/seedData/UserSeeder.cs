using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Infrastructure.seedData
{
    public static class UserSeeder
    {
        
        public static async void Initialize(this IServiceProvider serviceProvider)
        {
            // seed admin
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var email = "admin@admin.com";
            var name = "Admin";
            var password = "Admin@1234";
            try
            {
                var identityUser = new AppUser
                {
                    Id = "admin-1",
                    UserName = name,
                    Email = email,
                    EmailConfirmed = false,
                };
                await userManager.CreateAsync(identityUser, password);
                await userManager.AddToRoleAsync(identityUser, "Admin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace?.ReplaceLineEndings());
            }

            // seed user
            AppUser user = new AppUser()
            {
                Id = "use-1",
                ProfileImageUrl = "",
                Email = "nguyenvana@gmail.com",
                EmailConfirmed = false,
                Gender = 1,
                BirthDay = DateTime.Now,
                JoinTime = DateTime.Now,
                FullName = "Nguyễn Văn A",
                Addresses = new List<Address>(),
                Blogs = new List<Blog>(),
                Orders = new List<Order>(),
                IsDeleted = false,
                Status = true
            };
            try
            {
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "User");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace?.ReplaceLineEndings());
            }
        }
    }
}
