using furni.Infrastructure.IServices;
using Microsoft.Identity.Client;

namespace furni.Application.Interfaces.Management
{
    public interface ICategoryManageServices
    {
        public Task<IEnumerable<Dictionary<string, object>>> GetAllBrandAndProductByCategory();
        public Task<IEnumerable<Dictionary<string, object>>> GetAllCategory();
        public Task<Dictionary<string,object>> GetCategoryById(string categoryId);
        public Task<IEnumerable<Dictionary<string,object>>> GetCategoryByName(string name);
        public Task<Dictionary<string,object>> Add(string userId, string name, string description);
        public Task<Dictionary<string,object>> UpdateInfo(string userId, string name, string description);
        public Task<Dictionary<string, object>> UpdateStatus(string userId, string Category);
        public Task<Dictionary<string, object>> Delete(string userId, string brandId);
    }
}