using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class ColorServices(ApplicationDbContext context) : RepositoryAsync<Color>(context), IColorServices { }
}
