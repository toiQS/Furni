using furni.Application.Interfaces.Management;
using furni.Application.Management;


using furni.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using furni.Infrastructure.Configurations;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using furni.Presentation.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectString"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddTransient<ISendMailService, SendMailService>();

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddScoped<ICartManagement, CartManagement>();

builder.Services.AddScoped<IBrandManageServices, BrandManageServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<OrderHub>("/orderHub");
    endpoints.MapHub<CommentHub>("/commentHub");
});

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }

    }

}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var email = "admin@admin.com";
    var name = "Admin";
    var password = "Admin@1234";
    try
    {
        var identityUser = new AppUser
        {
            Id = "user-default",
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
}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var email = "user1@user1.com";
    var name = "user";
    var password = "User@1234";
    try
    {
        var identityUser = new AppUser
        {
            Id = "user-1",
            UserName = name,
            Email = email,
            EmailConfirmed = false,
        };
        await userManager.CreateAsync(identityUser, password);
        await userManager.AddToRoleAsync(identityUser, "User");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.WriteLine(ex.StackTrace?.ReplaceLineEndings());
    }
}
app.Run();
