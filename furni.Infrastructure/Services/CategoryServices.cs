using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
namespace furni.Infrastructure.Services
{
    public class CategoryServices(ApplicationDbContext dbContext): RepositoryAsync<Category>(dbContext),ICategoryServices{}
}