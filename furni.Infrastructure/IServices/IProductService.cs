using furni.Domain.Entities;

namespace furni.Infrastructure.IServices;

public interface IProductService : IRepositoryAsync<Product>
{
    public Task<List<Product>> GetProductByBrandIdAndCategoryId(int category, int brand);
}
