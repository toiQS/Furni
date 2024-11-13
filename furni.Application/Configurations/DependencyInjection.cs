using furni.Application.Interfaces.Management;
using furni.Application.Management;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace furni.Application.Configurations;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services);
    }

    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICartManagement, CartManagement>();
        services.AddScoped<IBrandManageServices, BrandManageServices>();
    }
}
