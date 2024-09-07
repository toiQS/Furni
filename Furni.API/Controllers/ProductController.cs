using Furni.API.Models;
using Furni.Entities;
using Furni.Services.product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Furni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var data = await _productServices.GetProductsAsync();
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Can't find data"));

            var result = data.Select(x => new ProductModel()
            {
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                Price = x.Price,
                ProductId = x.ProductId,
                URLImage = x.URLImage,
            });

            return Ok(ServiceResult<IEnumerable<ProductModel>>.SuccessResult(result));
        }

        // GET: api/Product/search?text=sample
        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByText(string text)
        {
            if (string.IsNullOrEmpty(text)) return BadRequest(ServiceResult<string>.FailureResult("Search text is required"));

            var data = await _productServices.GetProductsByText(text);
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("No matching products found"));

            var result = data.Select(x => new ProductModel()
            {
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                Price = x.Price,
                ProductId = x.ProductId,
                URLImage = x.URLImage,
            });

            return Ok(ServiceResult<IEnumerable<ProductModel>>.SuccessResult(result));
        }

        // GET: api/Product/sort/price
        [HttpGet("sort/price")]
        public async Task<IActionResult> SortProductByPrice()
        {
            var data = await _productServices.SortProductByPrice();
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("No products found"));

            var result = data.Select(x => new ProductModel()
            {
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                Price = x.Price,
                ProductId = x.ProductId,
                URLImage = x.URLImage,
            });

            return Ok(ServiceResult<IEnumerable<ProductModel>>.SuccessResult(result));
        }

        // GET: api/Product/{id}
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            if (string.IsNullOrEmpty(productId)) return BadRequest(ServiceResult<string>.FailureResult("Product ID is required"));

            var data = await _productServices.GetProductById(productId);
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Product not found"));

            var result = new ProductModel()
            {
                ProductName = data.ProductName,
                IsActive = data.IsActive,
                Price = data.Price,
                ProductId = data.ProductId,
                URLImage = data.URLImage,
            };

            return Ok(ServiceResult<ProductModel>.SuccessResult(result));
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string productName, float price, string imageUrl)
        {
            if (string.IsNullOrEmpty(productName) || price <= 0 || string.IsNullOrEmpty(imageUrl))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input data"));

            var result = await _productServices.CreateAsync(productName, price, imageUrl);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Product created successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to create product"));
        }

        // PUT: api/Product/{id}
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateAsync(string productId, string productName, float price, string imageUrl)
        {
            if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(productName) || price <= 0 || string.IsNullOrEmpty(imageUrl))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input data"));

            var result = await _productServices.UpdateAsync(productId, productName, price, imageUrl);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Product updated successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to update product"));
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                return BadRequest(ServiceResult<string>.FailureResult("Product ID is required"));

            var result = await _productServices.DeleteAsync(productId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Product deleted successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to delete product"));
        }
    }
}
