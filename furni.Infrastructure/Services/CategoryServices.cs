using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;
namespace furni.Infrastructure.Services
{
    public class CategoryServices(ApplicationDbContext dbContext): RepositoryAsync<Category>(dbContext),ICategoryServices
    {
        public async Task<List<Category>> GetCategoriesByName(string categoryName)
        {
            try
            {
                return await Table.Where(x => x.Name.ToLower().Contains(categoryName.ToLower())).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
