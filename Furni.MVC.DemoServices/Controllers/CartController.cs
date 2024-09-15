using Furni.Data;
using Furni.MVC.DemoServices.Models.cart;
using Furni.MVC.DemoServices.Models.item;
using Furni.Services.cart;
using Furni.Services.item;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace Furni.MVC.DemoServices.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IItemServices _itemServices;
        private readonly ApplicationDbContext _context;
        public CartController(ICartServices cartServices, IWebHostEnvironment webHostEnvironment)
        {
            _context = new ApplicationDbContext();
            _cartServices = cartServices;
            _webHostEnvironment = webHostEnvironment;
            _itemServices = new ItemServices(_context);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _cartServices.GetCartsAsync();
            var result = data.Select(x => new CartModelResponse()
            {
                CartId = x.CartId,
                UserId = x.UserId,
            });
            //return Json(result);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var data = await _cartServices.GetCartByIdAsync(id);
            if (data == null) return View("Can't found data");
            var dataItem = await _itemServices.GetItemByCartId(id);
            if (dataItem == null) return View("Can't found data");
            var resultItem = dataItem.Select(x => new ItemModelResponse()
            {
                ItemId = x.ItemId,
                Quantity = x.Quantity,

            });
            var resultcart = new CartModelDetail()
            {
                CartId = data.CartId,
                UserId = data.UserId,
                Items = resultItem.ToList(),
            };
            return View(resultcart);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(string userId)
        {
            //var result = await _cartServices.CreateAsync(userId);
            return Json(userId);
        }
        
    }
}
