using furni.Application.Interfaces.Repository;
using furni.Application.Interfaces.Service;
using furni.Entities;

namespace furni.Application.Service;

public class ProductService : IProductService
{
    private string _path = string.Empty, _fileName = "LogProductFile.txt", _folderName = "product";
    private IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _path = _productRepository.GetPathFolderCurrent();
    }

    public async Task<bool> CreateAsync(Product product)
    {
        try
        {
            var temp = new Product { ProductName = "abc1" };
            return await _productRepository.CreateAsync(temp);
        }
        catch (Exception ex)
        {
            await _productRepository.LogErrorAsync(_path, ex);
            throw;
        }
    }

    public async Task<IList<Product>> GetAsync()
    {
        try
        {
            return await _productRepository.GetAsync();
        }
        catch (Exception ex)
        {
            await _productRepository.LogErrorAsync(_path, ex);
            throw;
        }
    }
}
