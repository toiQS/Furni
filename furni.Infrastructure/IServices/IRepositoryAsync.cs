namespace furni.Infrastructure.IServices
{
    public interface IRepositoryAsync<T>
    {
        public Task<IList<T>> GetAsync();
        public Task<T> GetByIdAsync(string id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteAsync(string id);
        public Task<bool> UpdateAsync(string id,T entity);
    }
}
