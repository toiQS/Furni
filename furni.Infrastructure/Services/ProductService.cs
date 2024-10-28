using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Services;

namespace furni.Infrastructure.Service;

public class ProductService(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductService
{
    
}
