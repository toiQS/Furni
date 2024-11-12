using furni.Domain.Entities;

namespace furni.Infrastructure.IServices
{
    public interface IBrandServices : IRepositoryAsync<Brand>
    {
        public Task<IEnumerable<Brand>> GetBrandsByName(string name);
    }
}