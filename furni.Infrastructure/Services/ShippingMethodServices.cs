using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class ShippingMethodServices(ApplicationDbContext context) : RepositoryAsync<ShippingMethod>(context), IShippingMethodServices { }
}
