using furni.Entities;

namespace furni.Infrastructure.IServices;

public interface IProductService : IRepositoryAsync<Product>
{
    public Task<List<Product>> GetProductByBrandIdAndCategoryId(string category, string brand);
}
