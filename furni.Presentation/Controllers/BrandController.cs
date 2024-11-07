using furni.Application.Interfaces.Management;
using furni.Application.Management;
using furni.Infrastructure.IServices;
using furni.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace furni.Presentation.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandManager _brandManager;
        private readonly IUserServices _userServices;
        private readonly IBrandServices _brandServices;
        public BrandController(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }

        [HttpGet(Name = "Get All Brand")]
        public async Task<IActionResult> Index()
        {
            var brand = await _brandManager.GetAllBrand();
            return Json(brand);
        }
        [HttpGet(Name = "Get All Brand")]
        public async Task<IActionResult> Index2()
        {
            var brand = await _brandManager.GetAllBrand();
            var data = brand.Select(static x => new BrandResponse()
            {
                Id = x["Brand Id :"].ToString(),
                Name = x["Brand Name:"].ToString()
            }).ToList();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
