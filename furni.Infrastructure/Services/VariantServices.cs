using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class VariantServices(ApplicationDbContext context) : RepositoryAsync<Variant>(context), IVariantServices { }
}
