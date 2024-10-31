using furni.Entities;

namespace furni.Application.Interfaces.Management
{
    public interface IBrandManager
    {
        public Task<IEnumerable<Dictionary<string,object>>> GetAllBrand();
        public Task<IEnumerable<Dictionary<string,object>>> GetAllBrandByName(string name);
        public Task<Dictionary<string,string>> AddNewBrand(string userId, Brand brand);
        public Task<Dictionary<string,string>> EditBrand(string userId,string brandId, Brand brand);
        public Task<Dictionary<string ,string>> DeleteBrand(string userId,string brandId);
    }
}