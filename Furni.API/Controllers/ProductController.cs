using Furni.API.Models;
using Furni.Entities;
using Furni.Services.product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // Lấy danh sách sản phẩm (Mở rộng cho mọi người)
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var data = await _productServices.GetProductsAsync();
            if (data == null || !data.Any())
                return NotFound(ServiceResult<string>.FailureResult("No products found"));

            var result = data.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                Price = x.Price,
                ProductId = x.ProductId,
                URLImage = x.URLImage,
            });

            return Ok(ServiceResult<IEnumerable<ProductModel>>.SuccessResult(result));
        }

        // Tìm sản phẩm theo từ khóa (Mở rộng cho mọi người)
        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest(ServiceResult<string>.FailureResult("Search text is required"));

            var data = await _productServices.GetProductsByText(text);
            if (data == null || !data.Any())
                return NotFound(ServiceResult<string>.FailureResult("No matching products found"));

            var result = data.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                Price = x.Price,
                ProductId = x.ProductId,
                URLImage = x.URLImage,
            });

            return Ok(ServiceResult<IEnumerable<ProductModel>>.SuccessResult(result));
        }

        // Lấy sản phẩm theo ID (Mở rộng cho mọi người)
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                return BadRequest(ServiceResult<string>.FailureResult("Product ID is required"));

            var data = await _productServices.GetProductById(productId);
            if (data == null)
                return NotFound(ServiceResult<string>.FailureResult("Product not found"));

            var result = new ProductModel
            {
                ProductName = data.ProductName,
                IsActive = data.IsActive,
                Price = data.Price,
                ProductId = data.ProductId,
                URLImage = data.URLImage,
            };

            return Ok(ServiceResult<ProductModel>.SuccessResult(result));
        }

        // Tạo sản phẩm (Chỉ cho phép Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(string productName, float price, string imageUrl)
        {
            if (string.IsNullOrEmpty(productName) || price <= 0 || string.IsNullOrEmpty(imageUrl))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input data"));

            var result = await _productServices.CreateAsync(productName, price, imageUrl);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Product created successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to create product"));
        }

        // Cập nhật sản phẩm (Chỉ cho phép Admin)
        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(string productId, string productName, float price, string imageUrl)
        {
            if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(productName) || price <= 0 || string.IsNullOrEmpty(imageUrl))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input data"));

            var result = await _productServices.UpdateAsync(productId, productName, price, imageUrl);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Product updated successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to update product"));
        }

        // Xóa sản phẩm (Chỉ cho phép Admin)
        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                return BadRequest(ServiceResult<string>.FailureResult("Product ID is required"));

            var result = await _productServices.DeleteAsync(productId);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Product deleted successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to delete product"));
        }

        // Sắp xếp sản phẩm theo giá (Mở rộng cho mọi người)
        [HttpGet("sort/price")]
        public async Task<IActionResult> SortProductByPrice()
        {
            var data = await _productServices.SortProductByPrice();
            if (data == null || !data.Any())
                return NotFound(ServiceResult<string>.FailureResult("No products found"));

            var result = data.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                Price = x.Price,
                ProductId = x.ProductId,
                URLImage = x.URLImage,
            });

            return Ok(ServiceResult<IEnumerable<ProductModel>>.SuccessResult(result));
        }
    }
}
