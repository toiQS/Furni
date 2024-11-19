using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class SizeServices(ApplicationDbContext context) : RepositoryAsync<Size>(context), ISizeServices { }
}
