using Furni.API.Models;
using Furni.Entities;
using Furni.Services.item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices _itemServices;

        public ItemController(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        // Lấy danh sách tất cả các item của User
        [HttpGet]
        [Authorize(Roles = "User")]  // Chỉ User mới có quyền truy cập
        public async Task<IActionResult> GetItemsAsync()
        {
            var data = await _itemServices.GetItemsAsync();
            if (data == null || !data.Any())
                return NotFound(ServiceResult<string>.FailureResult("No items found"));

            var result = data.Select(x => new ItemModel
            {
                CartId = x.CartId,
                ItemId = x.ItemId,
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Total = x.Total
            });

            return Ok(ServiceResult<IEnumerable<ItemModel>>.SuccessResult(result));
        }

        // Lấy thông tin item theo ID
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]  // Chỉ User mới có quyền truy cập
        public async Task<IActionResult> GetItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(ServiceResult<string>.FailureResult("Item ID is required"));

            var data = await _itemServices.GetItemAsync(id);
            if (data == null)
                return NotFound(ServiceResult<string>.FailureResult("Item not found"));

            var result = new ItemModel
            {
                CartId = data.CartId,
                ItemId = data.ItemId,
                Price = data.Price,
                ProductId = data.ProductId,
                Quantity = data.Quantity,
                Total = data.Total
            };

            return Ok(ServiceResult<ItemModel>.SuccessResult(result));
        }

        // Lấy item theo Cart ID
        [HttpGet("cart/{cartId}")]
        [Authorize(Roles = "User")]  // Chỉ User mới có quyền truy cập
        public async Task<IActionResult> GetItemByCartId(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
                return BadRequest(ServiceResult<string>.FailureResult("Cart ID is required"));

            var data = await _itemServices.GetItemByCartId(cartId);
            if (data == null || !data.Any())
                return NotFound(ServiceResult<string>.FailureResult("Items not found for this cart"));

            var result = data.Select(x => new ItemModel
            {
                CartId = x.CartId,
                ItemId = x.ItemId,
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Total = x.Total
            });

            return Ok(ServiceResult<IEnumerable<ItemModel>>.SuccessResult(result));
        }

        // Tạo item mới
        [HttpPost]
        [Authorize(Roles = "User")]  // Chỉ User mới có quyền truy cập
        public async Task<IActionResult> CreateAsync(string productId, int quantity, string cartId)
        {
            if (string.IsNullOrEmpty(productId) || quantity <= 0 || string.IsNullOrEmpty(cartId))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input"));

            var result = await _itemServices.CreateAsync(productId, quantity, cartId);
            if (result)
                return StatusCode(StatusCodes.Status201Created, ServiceResult<string>.SuccessResult("Item created successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Unable to create item"));
        }

        // Cập nhật số lượng item
        [HttpPut("{itemId}")]
        [Authorize(Roles = "User")]  // Chỉ User mới có quyền truy cập
        public async Task<IActionResult> UpdateAsync(string itemId, int quantity)
        {
            if (string.IsNullOrEmpty(itemId) || quantity <= 0)
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input"));

            var result = await _itemServices.UpdateAsync(itemId, quantity);
            if (result)
                return NoContent(); // 204 No Content

            return BadRequest(ServiceResult<string>.FailureResult("Unable to update item"));
        }

        // Xóa item
        [HttpDelete("{itemId}")]
        [Authorize(Roles = "User")]  // Chỉ User mới có quyền truy cập
        public async Task<IActionResult> DeleteAsync(string itemId)
        {
            if (string.IsNullOrEmpty(itemId))
                return BadRequest(ServiceResult<string>.FailureResult("Item ID is required"));

            var result = await _itemServices.DeleteAsync(itemId);
            if (result)
                return NoContent(); // 204 No Content

            return BadRequest(ServiceResult<string>.FailureResult("Unable to delete item"));
        }
    }
}
