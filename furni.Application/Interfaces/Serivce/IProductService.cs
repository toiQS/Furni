using furni.Entities;

namespace furni.Application.Interfaces.Service;

public interface IProductService
{
    Task<bool> CreateAsync(Product product);

    Task<IList<Product>> GetAsync();
}
