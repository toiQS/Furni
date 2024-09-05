using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Services.blog
{
    public class BlogServices : IBlogServices
    {
        private readonly ApplicationDbContext _context;
        private IRepositoryAsync<Blog> _blogRepository;
        private string _path;
        // Constructor for API Controller
        public BlogServices(ApplicationDbContext context)
        {
            _context = context;
            _blogRepository = new RepositoryAsync<Blog>(context);
            _blogRepository.GetFileName("LogBlogFile.txt");
            _blogRepository.GetFolderName("blog");
            _path = _blogRepository.GetPathFolderCurrent();
        }
        public async Task<IEnumerable<Blog>> GetBlogListAsync()
        {
            return await _blogRepository.GetValuesAsync();
        }
        public async Task<Blog> GetBlogByIdAsync(string id)
        {
            try
            {
                return await _context.Blog.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            }
            catch (Exception ex)
            {
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<IEnumerable<Blog>> GetBlogsByTextAsync(string text)
        {
            try
            {
                return await _context.Blog.AsNoTracking().Where(x => x.BlogName.ToLower().Contains(text.ToLower())).ToListAsync();
            }
            catch (Exception ex)
            {
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
        public async Task<bool> CreateAsync(string blogName, string userIdCreated)
        {
            var data = new Blog()
            {
                BlogName = blogName,
                BlogId = $"BF{DateTime.Now.Ticks}",
                CreateAt = DateTime.Now,
                UserIdCreated = userIdCreated,
                UpdateAt = DateTime.Now,
            };
            return await _blogRepository.Create(data);
        }
        public async Task<bool> UpdateAsync(string blogId, string blogName, string userIdCreated)
        {
            try
            {
                var data = await _context.Blog.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == blogId);
                if (data == null) return false;
                data.BlogName = blogName;
                data.UserIdCreated = userIdCreated;
                data.UpdateAt = DateTime.Now;
                return await _blogRepository.Update(data);
            }
            catch (Exception ex)
            {
                await _blogRepository.LogErrorAsync(_path,ex);
                throw;
            }
        }
        public async Task<bool> DeleteAsync(string blogId)
        {
            try
            {
                var data = await _context.Blog.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == blogId);
                if (data == null) return false;
                return await _blogRepository.Delete(data);
            }
            catch (Exception ex)
            {
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
