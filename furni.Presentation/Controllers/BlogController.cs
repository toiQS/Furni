using furni.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using furni.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace furni.Presentation.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BlogController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_context.Blog != null)
            {
                var topicsWithCount = await _context.Topic
                   .Select(topic => new
                   {
                       Topic = topic,
                       blogCount = _context.Blog.Count(blog => blog.TopicId == topic.Id)
                   })
                   .ToListAsync();
                ViewBag.topics = topicsWithCount;
                ViewBag.Blog = await _context.Blog
                     //.Include(blog => blog.Image)
                     //.Include(blog => blog.Topic)
                     //.Include(blog => blog.AppUser)
                     .OrderByDescending(blog => blog.CreateAt)
                     .ToListAsync();
                return View();
            }
            return Problem("Entity set 'AppDbContext.Blog'  is null.");
        }

        //public async Task<IActionResult> Detail(int id)
        //{
        //	if (id == null || _context.Blogs == null) return NotFound();

        //	var blog = await _context.Blogs
        //		.Include(b => b.Topic)
        //		.Include(b => b.Thumbnail)
        //              .Include(b => b.User)
        //		.FirstOrDefaultAsync(m => m.Id == id);
        //	if (blog == null) return NotFound();
        //          ViewBag.Blog = blog;
        //	return View();
        //}

        [Route("/blogs/{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            if (_context.Blog == null) return NotFound();
            var blog = await _context.Blog.FirstOrDefaultAsync(p => p.Slug == slug);
            if (blog == null || blog.IsDeteled) return NotFound();
            ViewBag.Blog = blog;
            ViewBag.Related = await _context.Blog
                //.Include(b => b.Image)
                //.Include(b => b.Topic)
                //.Include(b => b.AppUser)
                .OrderByDescending(blog => blog.CreateAt)
                .Take(5).ToListAsync();
            return View();
        }


        [HttpGet, ActionName("getallblogs")]
        public IActionResult GetAllBlogs(
        int page = 1,
        int pageSize = 2,
        string query = "",
        string topics = ""
        )
        {
            var queryableBlogs = _context.Blog
                .Where(b => !b.IsDeteled && b.IsPublic)
                //.Include(blog => blog.Topic)
                //.Include(blog => blog.Image)
                //.Include(blog => blog.AppUser)
                .OrderByDescending(b => b.CreateAt)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                queryableBlogs = queryableBlogs.Where(u =>
                    u.Slug.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    u.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    u.AppUser.FullName.Contains(query, StringComparison.OrdinalIgnoreCase)
                );
            }
            // Filter by topics
            if (!string.IsNullOrEmpty(topics))
            {
                string[] cate = topics.Split(',');
                queryableBlogs = queryableBlogs.Where(u => cate.Contains(u.TopicId.ToString()));
            }


            // Paginate results
            var totalItems = queryableBlogs.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var currentPageBlog = queryableBlogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                MaxDepth = 100,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
            };

            var result = new
            {
                CurrentPage = page,
                TotalPages = totalPages,
                TotalItems = totalItems,
                Result = currentPageBlog
            };

            return Ok(JsonSerializer.Serialize(result, options));
        }
    }
}
