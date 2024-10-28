using furni.Application.Interfaces.Management;
//using furni.Application.Interfaces.Service;
using furni.Entities;
using furni.Infrastructure.IServices;

namespace furni.Application.Management;

public class ProductManagement : IProductManagement
{
    private IProductService _productService;

    public ProductManagement(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<bool> CreateAsync(Product product)
    {
        try
        {
            var temp = new Product { ProductName = "abc1" };
            return await _productService.CreateAsync(temp);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IList<Product>> GetAsync()
    {
        try
        {
            return await _productService.GetAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
