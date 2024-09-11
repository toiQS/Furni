using Furni.API.Models;
using Furni.Entities;
using Furni.Services.blog;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Furni.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogServices _blogServices;
        
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        // Get all blogs asynchronously
        [HttpGet("list")]
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> GetBlogListAsync()
        {
            var data = await _blogServices.GetBlogListAsync();
            if (data == null || !data.Any())
            {
                return NotFound(ServiceResult<string>.FailureResult("No blogs found."));
            }

            var result = data.Select(x => new BlogModel()
            {
                BlogName = x.BlogName,
                BlogId = x.BlogId,
                CreateAt = DateTime.Now,  // You should use x.CreateAt if available
                UpdateAt = DateTime.Now,  // Same with x.UpdateAt
                UserIdCreated = x.UserIdCreated
            }).ToArray();

            return Ok(ServiceResult<IEnumerable<BlogModel>>.SuccessResult(result));
        }

        // Get a blog by ID asynchronously
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Blog ID cannot be null or empty."));
            }

            var data = await _blogServices.GetBlogByIdAsync(id);
            if (data == null)
            {
                return NotFound(ServiceResult<string>.FailureResult("Blog not found."));
            }

            var result = new BlogModel()
            {
                BlogName = data.BlogName,
                BlogId = data.BlogId,
                CreateAt = DateTime.Now, // You should use data.CreateAt if available
                UpdateAt = DateTime.Now, // Same with data.UpdateAt
                UserIdCreated = data.UserIdCreated
            };

            return Ok(ServiceResult<BlogModel>.SuccessResult(result));
        }

        // Get blogs by search text asynchronously
        [HttpGet("search")]
        public async Task<IActionResult> GetBlogsByTextAsync(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Search text cannot be null or empty."));
            }

            var data = await _blogServices.GetBlogsByTextAsync(text);
            if (data == null || !data.Any())
            {
                return NotFound(ServiceResult<string>.FailureResult("No blogs found matching the search criteria."));
            }

            var result = data.Select(x => new BlogModel()
            {
                BlogName = x.BlogName,
                BlogId = x.BlogId,
                CreateAt = x.CreateAt, 
                UpdateAt = x.UpdateAt,
                UserIdCreated = x.UserIdCreated
            }).ToArray();

            return Ok(ServiceResult<IEnumerable<BlogModel>>.SuccessResult(result));
        }

        // Create a new blog asynchronously
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string blogName, string userIdCreated)
        {
            if (string.IsNullOrEmpty(blogName) || string.IsNullOrEmpty(userIdCreated))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Blog name and creator ID cannot be null or empty."));
            }

            var result = await _blogServices.CreateAsync(blogName, userIdCreated);
            if (result)
            {
                return Ok(ServiceResult<string>.SuccessResult("Blog created successfully."));
            }

            return BadRequest(ServiceResult<string>.FailureResult("Failed to create blog."));
        }

        // Update an existing blog asynchronously
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(string blogId, string blogName, string userIdCreated)
        {
            if (string.IsNullOrEmpty(blogId) || string.IsNullOrEmpty(blogName) || string.IsNullOrEmpty(userIdCreated))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Blog ID, name, and creator ID cannot be null or empty."));
            }

            var result = await _blogServices.UpdateAsync(blogId, blogName, userIdCreated);
            if (result)
            {
                return Ok(ServiceResult<string>.SuccessResult("Blog updated successfully."));
            }

            return BadRequest(ServiceResult<string>.FailureResult("Failed to update blog."));
        }

        // Delete a blog asynchronously
        [HttpDelete("{blogId}")]
        public async Task<IActionResult> DeleteAsync(string blogId)
        {
            if (string.IsNullOrEmpty(blogId))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Blog ID cannot be null or empty."));
            }

            var result = await _blogServices.DeleteAsync(blogId);
            if (result)
            {
                return Ok(ServiceResult<string>.SuccessResult("Blog deleted successfully."));
            }

            return BadRequest(ServiceResult<string>.FailureResult("Failed to delete blog."));
        }
    }
}
