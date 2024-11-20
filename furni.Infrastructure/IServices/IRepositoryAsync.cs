namespace furni.Infrastructure.IServices
{
    public interface IRepositoryAsync<T>
    {
        public Task<IList<T>> GetAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id,T entity);
    }
}
