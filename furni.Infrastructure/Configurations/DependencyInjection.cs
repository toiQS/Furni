using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Service;
using furni.Infrastructure.Services;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        services.AddScoped<IAddressServices, AddressServices>();
        services.AddScoped<IBlogServices, BlogServices>();
        services.AddScoped<IBrandServices, BrandServices>();
        services.AddScoped<ICategoryServices, CategoryServices>();
        services.AddScoped<IColorServices, ColorServices>();
        services.AddScoped<IContactServices, ContactServices>();
        services.AddScoped<IImageServices, ImageServices>();
        services.AddScoped<IOrderServices, OrderServices>();
        services.AddScoped<IOrderDetailServices, OrderDetailServices>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IReviewServices, ReviewServices>();
        services.AddScoped<IShippingMethodServices, ShippingMethodServices>();
        services.AddScoped<ISizeServices, SizeServices>();
        services.AddScoped<ITopicServices, TopicServices>();
        services.AddScoped<IVariantServices, VariantServices>();
        services.AddScoped<IVariantSizeServices, VariantSizeServices>();
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
