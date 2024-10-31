using furni.Entities;
namespace furni.Infrastructure.IServices
{
    public interface ICategoryServices : IRepositoryAsync<Category>
    {
        public Task<IEnumerable<Category>> GetCategoriesByName(string name);
    }
}