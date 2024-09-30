using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.repository
{
    public interface IRepositoryAsync<T>
    {
        public Task<IEnumerable<T>> GetValuesAsync();
        public Task<bool> Create(T entity);
        public Task<bool> Delete(T entity);
        public Task<bool> Update(T entity);
        public string GetPathFolderCurrent();
        public string GetFolderName(string folderName);
        public string GetFileName(string fileName);
        public Task LogErrorAsync(string path, Exception ex);
    }
}
