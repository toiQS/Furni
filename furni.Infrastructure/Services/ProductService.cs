using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.Interfaces;

namespace furni.Infrastructure.Service;

public class ProductService(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductService
{

}
