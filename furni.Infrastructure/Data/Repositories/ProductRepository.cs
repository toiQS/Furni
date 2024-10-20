using furni.Application.Interfaces.Repository;
using furni.Entities;
using furni.Services.repository;

namespace furni.Infrastructure.Data.Repository;

public class ProductRepository(ApplicationDbContext context) : RepositoryAsync<Product>(context), IProductRepository
{

}
