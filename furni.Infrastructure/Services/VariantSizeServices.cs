using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class VariantSizeServices(ApplicationDbContext context) : RepositoryAsync<VariantSize>(context), IVariantSizeServices { }
}
