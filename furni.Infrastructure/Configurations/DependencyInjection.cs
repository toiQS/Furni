using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.SeedData;
using furni.Infrastructure.Service;
using furni.Infrastructure.Services;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace furni.Infrastructure.Configurations;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigurationConnectionToDataBase(services, configuration);
        RegisterServices(services);
        AddAuth(services);
        
    }
    public static void ConfigurationConnectionToDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DockerConnetcString") ?? string.Empty;
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
    public static void RegisterServices(IServiceCollection services)
    {

        services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<ICartServices, CartServices>();
        //services.AddScoped<ICartDetailServices, CartDetailServices>();

        services.AddScoped<IProductService,ProductService>();
        services.AddScoped<IBrandServices,BrandServices>();
        services.AddScoped<IUserServices,UserServices>();
        services.AddScoped<ISendMailService, SendMailService>();    
    }
    
    public static void AddAuth(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    }
    
}
