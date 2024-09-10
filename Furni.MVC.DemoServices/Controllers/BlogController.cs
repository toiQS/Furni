using Furni.MVC.DemoServices.Models;
using Furni.Services.blog;
using Microsoft.AspNetCore.Mvc;

namespace Furni.MVC.DemoServices.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogServices _blogServices;
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _blogServices.GetBlogListAsync();
            var result = data.Select(x => new BlogModel()
            {
                BlogName = x.BlogName,
                BlogId = x.BlogId,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                UserIdCreated = x.UserIdCreated,
            });
            return View(result);
        }
        public async Task<IActionResult> Add(BlogModelRequest model)
        {
            return View(model);
        }
        public async Task<IActionResult> Add(string blogName, string userIdCreate)
        {
            if (!ModelState.IsValid) return View();
            var result = await _blogServices.CreateAsync(blogName, userIdCreate);
            return RedirectToAction("Index");
        }
    }
}
