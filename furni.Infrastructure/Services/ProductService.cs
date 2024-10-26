using furni.Application.Interfaces.Service;
using furni.Entities;
using furni.Services.repository;

namespace furni.Infrastructure.Data.Repository;

public class ProductService(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductService
{

}
