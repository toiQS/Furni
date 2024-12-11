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
using furni.Infrastructure.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectString1"));
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
    endpoints.MapAreaControllerRoute(
      name: "Admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller}/{action}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<OrderHub>("/orderHub");
    endpoints.MapHub<CommentHub>("/commentHub");
});

using (var scope = app.Services.CreateScope()) // Create a scoped service provider
{
    var services = scope.ServiceProvider;

    // Pass the scoped service provider to the seeder
    BrandSeeder.Initialize(services);
}


app.Run();
