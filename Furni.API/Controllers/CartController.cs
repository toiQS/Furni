using Furni.API.Models;
using Furni.Entities;
using Furni.Services.cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security;

namespace Furni.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        // Lấy danh sách tất cả giỏ hàng - chỉ cho Admin và Manager
        [HttpGet(Name = "GetCartsAsync")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetCartsAsync()
        {
            var data = await _cartServices.GetCartsAsync();
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Cannot find data"));
            var result = data.Select(x => new CartModel()
            {
                CartId = x.CartId,
                Status = x.Status,
                UserId = x.UserId,
            });
            return Ok(ServiceResult<IEnumerable<CartModel>>.SuccessResult(result));
        }

        // Lấy thông tin giỏ hàng theo ID - Mở cho User trở lên
        [HttpGet("{id}", Name = "GetCartByIdAsync")]
        [Authorize(Roles = "User,Member,Admin,Manager")]
        public async Task<IActionResult> GetCartByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest(ServiceResult<string>.FailureResult("Id was null"));
            var data = await _cartServices.GetCartByIdAsync(id);
            if (data == null) return NotFound(ServiceResult<string>.FailureResult($"Could not find cart with id {id}"));
            var result = new CartModel()
            {
                CartId = data.CartId,
                Status = data.Status,
                UserId = data.UserId,
            };
            return Ok(ServiceResult<CartModel>.SuccessResult(result));
        }

        // Lấy giỏ hàng theo trạng thái true (hoạt động) - chỉ cho Admin và Manager
        [HttpGet("status/true", Name = "GetCartsByStatusTrue")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetCartsByStatusTrue()
        {
            var data = await _cartServices.GetCartsByStatusTrue();
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Cannot find data"));
            var result = data.Select(x => new CartModel()
            {
                CartId = x.CartId,
                Status = x.Status,
                UserId = x.UserId,
            });
            return Ok(ServiceResult<IEnumerable<CartModel>>.SuccessResult(result));
        }

        // Lấy giỏ hàng theo trạng thái false (không hoạt động) - chỉ cho Admin và Manager
        [HttpGet("status/false", Name = "GetCartsByStatusFalse")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetCartsByStatusFalse()
        {
            var data = await _cartServices.GetCartsByStatusFalse();
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Cannot find data"));
            var result = data.Select(x => new CartModel()
            {
                CartId = x.CartId,
                Status = x.Status,
                UserId = x.UserId,
            });
            return Ok(ServiceResult<IEnumerable<CartModel>>.SuccessResult(result));
        }

        // Lấy giỏ hàng theo User ID - cho User trở lên
        [HttpGet("user/{userId}", Name = "GetCartsByUserId")]
        [Authorize(Roles = "User,Member,Admin,Manager")]
        public async Task<IActionResult> GetCartsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("User Id was null"));
            var data = await _cartServices.GetCartsByUserId(userId);
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Cannot find data"));
            var result = data.Select(x => new CartModel()
            {
                CartId = x.CartId,
                Status = x.Status,
                UserId = x.UserId,
            });
            return Ok(ServiceResult<IEnumerable<CartModel>>.SuccessResult(result));
        }

        // Tìm kiếm nâng cao theo User ID và trạng thái - chỉ cho Admin và Manager
        [HttpGet("search", Name = "AdvancedSearch")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AdvancedSearch(string userId, bool status)
        {
            if (string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("User Id was null or invalid"));
            var data = await _cartServices.AdvancedSearch(userId, status);
            if (data == null) return NotFound(ServiceResult<string>.FailureResult("Cannot find data"));
            var result = data.Select(x => new CartModel()
            {
                CartId = x.CartId,
                Status = x.Status,
                UserId = x.UserId,
            });
            return Ok(ServiceResult<IEnumerable<CartModel>>.SuccessResult(result));
        }

        // Tạo giỏ hàng mới - chỉ cho User trở lên
        [HttpPost(Name = "CreateCart")]
        [Authorize(Roles = "User,Member,Admin,Manager")]
        public async Task<IActionResult> CreateAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("User Id was null"));
            var result = await _cartServices.CreateAsync(userId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Cart created successfully"));
            return BadRequest(ServiceResult<string>.FailureResult("Failed to create cart"));
        }

        // Cập nhật giỏ hàng - chỉ Admin hoặc Manager
        [HttpPut(Name = "UpdateCart")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateAsync(string cartId, string userId)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("Cart Id or User Id was null"));
            var result = await _cartServices.UpdateAsync(cartId, userId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Cart updated successfully"));
            return BadRequest(ServiceResult<string>.FailureResult("Failed to update cart"));
        }

        // Xóa giỏ hàng - chỉ Admin
        [HttpDelete(Name = "DeleteCart")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(string cartId, string userId)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("Cart Id or User Id was null"));
            var result = await _cartServices.DeleteAsync(cartId, userId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Cart deleted successfully"));
            return BadRequest(ServiceResult<string>.FailureResult("Failed to delete cart"));
        }
    }
}
