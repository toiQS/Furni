using furni.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;
namespace furni.Infrastructure.Services
{
    public class CategoryServices(ApplicationDbContext dbContext): RepositoryAsync<Category>(dbContext),ICategoryServices
    {
        private readonly ApplicationDbContext _context;
        public async Task<IEnumerable<Category>> GetCategoriesByName(string name)
        {
            try
            {
                return await _context.Category.Where(x => x.CategoryName.ToLower().Contains(name.ToLower())).ToArrayAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Category>();
            }
        }
    }
}