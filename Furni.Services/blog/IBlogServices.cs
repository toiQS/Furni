using Furni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Furni.Services.blog
{
    public interface IBlogServices
    {
        public Task<IEnumerable<Blog>> GetBlogListAsync();
        public Task<Blog> GetBlogByIdAsync(string id);
        public Task<IEnumerable<Blog>> GetBlogsByTextAsync(string text);
        public Task<bool> CreateAsync(string blogName, string userIdCreated,string urlImage);
        public Task<bool> UpdateAsync(string blogId, string blogName, string userIdCreated,string urlImage);
        public Task<bool> DeleteAsync(string blogId);
    }
}
