using Furni.Data;
using Furni.Entities;
using Furni.Services.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.Services.blog
{
    public class BlogServices : IBlogServices
    {
        private readonly ApplicationDbContext _context; // Database context for accessing data
        private readonly IRepositoryAsync<Blog> _blogRepository; // Repository for managing Blog entities
        private readonly string _path; // Path for logging errors

        // Constructor for API Controller
        public BlogServices(ApplicationDbContext context)
        {
            _context = context;
            _blogRepository = new RepositoryAsync<Blog>(context); // Initialize blog repository

            // Set up log file and folder name
            _blogRepository.GetFileName("LogBlogFile.txt");
            _blogRepository.GetFolderName("blog");

            // Get current folder path for logging
            _path = _blogRepository.GetPathFolderCurrent();
        }

        // Fetches the complete list of blogs asynchronously
        public async Task<IEnumerable<Blog>> GetBlogListAsync()
        {
            return await _blogRepository.GetValuesAsync();
        }

        // Fetches a blog by its unique identifier asynchronously
        public async Task<Blog> GetBlogByIdAsync(string id)
        {
            try
            {
                return await _context.Blog.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.BlogId == id);
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Searches blogs by text contained in the blog name asynchronously
        public async Task<IEnumerable<Blog>> GetBlogsByTextAsync(string text)
        {
            try
            {
                return await _context.Blog.AsNoTracking()
                    .Where(x => x.BlogName.ToLower().Contains(text.ToLower()))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Creates a new blog asynchronously
        public async Task<bool> CreateAsync(string blogName, string userIdCreated)
        {
            var newBlog = new Blog()
            {
                BlogName = blogName,
                BlogId = $"BF{DateTime.Now.Ticks}", // Generate unique BlogId using ticks
                CreateAt = DateTime.Now,
                UserIdCreated = userIdCreated,
                UpdateAt = DateTime.Now,
            };

            return await _blogRepository.Create(newBlog);
        }

        // Updates an existing blog asynchronously
        public async Task<bool> UpdateAsync(string blogId, string blogName, string userIdCreated)
        {
            try
            {
                // Fetch blog entity by blogId
                var existingBlog = await _context.Blog.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.BlogId == blogId);

                if (existingBlog == null) return false; // Return false if blog is not found

                // Update blog fields
                existingBlog.BlogName = blogName;
                existingBlog.UserIdCreated = userIdCreated;
                existingBlog.UpdateAt = DateTime.Now;

                return await _blogRepository.Update(existingBlog); // Update blog in the repository
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }

        // Deletes a blog by its unique identifier asynchronously
        public async Task<bool> DeleteAsync(string blogId)
        {
            try
            {
                // Fetch blog entity by blogId
                var existingBlog = await _context.Blog.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.BlogId == blogId);

                if (existingBlog == null) return false; // Return false if blog is not found

                return await _blogRepository.Delete(existingBlog); // Delete blog from the repository
            }
            catch (Exception ex)
            {
                // Log error in case of exception
                await _blogRepository.LogErrorAsync(_path, ex);
                throw;
            }
        }
    }
}
