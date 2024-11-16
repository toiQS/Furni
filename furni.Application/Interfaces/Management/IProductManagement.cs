using furni.Domain.Entities;

namespace furni.Application.Interfaces.Management;

public interface IProductManagement
{
    Task<bool> CreateAsync(Product product);

    Task<IList<Product>> GetAsync();
}
