using furni.Application.Interfaces.Management;
using furni.Application.Management;
using furni.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace furni.Presentation.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandManageServices _brandManager;
        private readonly IUserServices _userServices;
        private readonly IBrandServices _brandServices;
        public BrandController(IBrandManageServices brandManager)
        {
            _brandManager = brandManager;
        }

        [HttpGet(Name = "Get All Brand")]
        public async Task<IActionResult> Index()
        {
            var brand = await _brandManager.GetAllBrand();
            return Json(brand);
        }
    }
}
