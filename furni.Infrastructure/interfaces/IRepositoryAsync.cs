namespace furni.Infrastructure.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        public Task<IList<T>> GetAsync();
        public Task<T> GetByIdAsync(string id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
    }
}
