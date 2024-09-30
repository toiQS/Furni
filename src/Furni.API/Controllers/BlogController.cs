using Furni.API.Models;
using Furni.Services.blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // Get all blogs asynchronously (Chỉ thành viên đã đăng nhập với vai trò "Member" mới được phép truy cập)
        [HttpGet("list")]
        [Authorize(Roles = "Member,Admin,Manager")]  // Cho phép các vai trò Member, Admin, Manager truy cập
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
                UserIdCreated = x.UserIdCreated,
                URLImage = x.URLImage,
            }).ToArray();

            return Ok(ServiceResult<IEnumerable<BlogModel>>.SuccessResult(result));
        }

        // Get a blog by ID asynchronously (Mở cho tất cả các User đã xác thực)
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Member,Admin,Manager")]
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
                CreateAt = data.CreateAt,
                UpdateAt = data.UpdateAt,
                UserIdCreated = data.UserIdCreated,
                URLImage = data.URLImage,
            };

            return Ok(ServiceResult<BlogModel>.SuccessResult(result));
        }

        // Get blogs by search text asynchronously (Chỉ cho thành viên "Member" trở lên)
        [HttpGet("search")]
        [Authorize(Roles = "Member,Admin,Manager")]
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
                UserIdCreated = x.UserIdCreated,
                URLImage = x.URLImage,
            }).ToArray();

            return Ok(ServiceResult<IEnumerable<BlogModel>>.SuccessResult(result));
        }

        // Create a new blog asynchronously (Chỉ Admin hoặc Manager có quyền tạo mới blog)
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateAsync(string blogName, string userIdCreated, string urlImage)
        {
            if (string.IsNullOrEmpty(blogName) || string.IsNullOrEmpty(userIdCreated) || string.IsNullOrEmpty(urlImage))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Blog name and creator ID cannot be null or empty."));
            }

            var result = await _blogServices.CreateAsync(blogName, userIdCreated, urlImage);
            if (result)
            {
                return Ok(ServiceResult<string>.SuccessResult("Blog created successfully."));
            }

            return BadRequest(ServiceResult<string>.FailureResult("Failed to create blog."));
        }

        // Update an existing blog asynchronously (Chỉ Admin hoặc Manager có quyền sửa blog)
        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateAsync(string blogId, string blogName, string userIdCreated, string urlImage)
        {
            if (string.IsNullOrEmpty(blogId) || string.IsNullOrEmpty(blogName) || string.IsNullOrEmpty(userIdCreated) || string.IsNullOrEmpty(urlImage))
            {
                return BadRequest(ServiceResult<string>.FailureResult("Blog ID, name, and creator ID cannot be null or empty."));
            }

            var result = await _blogServices.UpdateAsync(blogId, blogName, userIdCreated, urlImage);
            if (result)
            {
                return Ok(ServiceResult<string>.SuccessResult("Blog updated successfully."));
            }

            return BadRequest(ServiceResult<string>.FailureResult("Failed to update blog."));
        }

        // Delete a blog asynchronously (Chỉ Admin có quyền xóa blog)
        [HttpDelete("{blogId}")]
        [Authorize(Roles = "Admin")]
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
