namespace furni.Services.repository
{
    public interface IRepositoryAsync<T>
    {
        public Task<IList<T>> GetAsync();
        public Task<T> GetByIdAsync(string id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public string GetPathFolderCurrent();
        public string GetFolderName(string folderName);
        public string GetFileName(string fileName);
        public Task LogErrorAsync(string path, Exception ex);
    }
}
