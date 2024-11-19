using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class ProductVariantServices(ApplicationDbContext context) : RepositoryAsync<ProductVariant>(context), IProductVariantServices { }
}
