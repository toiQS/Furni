using furni.Entities;

namespace furni.Application.Interfaces.Management
{
    public interface IBrandManageServices
    {
        public Task<IEnumerable<Dictionary<string,object>>> GetAllBrand();
        public Task<IEnumerable<Dictionary<string,object>>> GetAllBrandByName(string name);
        public Task<Dictionary<string,string>> AddNewBrand(string userId, string name, string description, string email, string phone);
        public Task<Dictionary<string,string>> UpdateBrandInfo(string userId,string brandId, string name, string description, string email, string phone);        
        public Task<Dictionary<string ,string>> DeleteBrand(string userId,string brandId);
        public Task<Dictionary<string ,string>> UpdateBrandStastus(string userId, string brandId);
        
    }
}