using furni.Domain.Entities;
namespace furni.Infrastructure.IServices
{
    public interface ICategoryServices : IRepositoryAsync<Category>
    {
        Task<List<Category>> GetCategoriesByName(string categoryName);
    }
}
