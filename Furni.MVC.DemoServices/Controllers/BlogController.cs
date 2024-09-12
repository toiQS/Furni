﻿using Furni.MVC.DemoServices.Models;
using Furni.MVC.DemoServices.Models.blog;
using Furni.Services.blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Furni.MVC.DemoServices.Controllers
{
    public class BlogController : Controller
    {
        private IBlogServices _blogService;
        private IWebHostEnvironment _webHostEnvironment;
        public BlogController(IBlogServices blogService, IWebHostEnvironment webHostEnvironment)
        {
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _blogService.GetBlogListAsync();
            
            var result = data.Select(x => new BlogModelResponse()
            {
                BlogName = x.BlogName,
                BlogId = x.BlogId,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                UserIdCreated = x.UserIdCreated,
            });
            return View(result);
        }
        // Hiển thị form create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        

        // Xử lý việc submit form create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogModelRequest model)
        {
            if (ModelState.IsValid)
            {
                // Tạo mới blog
                await _blogService.CreateAsync(model.BlogName, model.UserIdCreated);

                // Chuyển hướng đến trang index sau khi tạo thành công
                return RedirectToAction(nameof(Index));
            }

            // Nếu model không hợp lệ, trả lại view với lỗi
            return View(model);
            //return Json(model);
        }
        // Hiển thị chi tiết blog
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            var model = new BlogModelResponse
            {
                BlogId = blog.BlogId,
                BlogName = blog.BlogName,
                UserIdCreated = blog.UserIdCreated,
                CreateAt = blog.CreateAt,
                UpdateAt = blog.UpdateAt
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return View(new ErrorViewModel());
            var data = await _blogService.GetBlogByIdAsync(id);
            if(data == null) return View(new ErrorViewModel());
            var result = new BlogModelRequest()
            {
                BlogName = data.BlogName,
                UserIdCreated = data.UserIdCreated,
            };
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, BlogModelRequest model)
        {
            var result = await _blogService.UpdateAsync(id, model.BlogName, model.UserIdCreated);
            if (result) return RedirectToAction("Index");
            return View(model);
            //return Json(id, new {model.BlogName, model.UserIdCreated});
        }
        

    }
}