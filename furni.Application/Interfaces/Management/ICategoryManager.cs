using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using furni.Entities;

namespace furni.Application.Interfaces.Management
{
    public interface ICategoryManager
    {
        public Task<IEnumerable<Dictionary<string,object>>> GetAllCategory();
        public Task<IEnumerable<Dictionary<string, object>>> GetAllCategoryByCategoryName(string name);
        public Task<Dictionary<string,string>> AddNewCategory(string userId, Category category);
        public Task<Dictionary<string,string>> UpdateCategory(string userId, string categoryId, Category category);
        public Task<Dictionary<string,string>> DeleteCategory(string userId,string categoryId);
    }
}
