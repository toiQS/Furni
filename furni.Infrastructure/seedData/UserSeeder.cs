using furni.Domain.Entities;
using furni.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class UserSeeder
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        // Seed admin
        var adminId = "admin-1";
        if (await userManager.FindByIdAsync(adminId) == null)
        {
            var adminUser = new AppUser
            {
                Id = adminId,
                UserName = "Admin",
                Email = "admin@admin.com",
                EmailConfirmed = true,
            };

            var createAdminResult = await userManager.CreateAsync(adminUser, "Admin@1234");
            if (createAdminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, UserRoles.Admin);
            }
        }

        // Seed user
        var userId = "use-1";
        if (await userManager.FindByIdAsync(userId) == null)
        {
            var normalUser = new AppUser
            {
                Id = userId,
                UserName = "NguyenVanA",
                Email = "nguyenvana@gmail.com",
                EmailConfirmed = true,
                FullName = "Nguyễn Văn A",
                BirthDay = DateTime.Now,
                JoinTime = DateTime.Now,
                Gender = 1,
                IsDeleted = false,
                Status = true,
            };

            var createUserResult = await userManager.CreateAsync(normalUser, "User@1234");
            if (createUserResult.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, UserRoles.Customer);
            }
        }
    }
}
