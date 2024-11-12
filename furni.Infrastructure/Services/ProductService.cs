using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace furni.Infrastructure.Service;

public class ProductService(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductService
{
    public async Task<List<Product>> GetProductByBrandIdAndCategoryId(string category, string brand)
    {
        try
        {
            return await Table.Where(x => x.BrandId == brand && x.CategoryId == category).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
