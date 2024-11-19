using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class AddressServices(ApplicationDbContext context) : RepositoryAsync<Address>(context), IAddressServices { }
}
