using Furni.API.Models;
using Furni.Entities;
using Furni.Services.cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "GetCartsAsync")]
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

        [HttpGet("{id}", Name = "GetCartByIdAsync")]
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

        [HttpGet("status/true", Name = "GetCartsByStatusTrue")]
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

        [HttpGet("status/false", Name = "GetCartsByStatusFalse")]
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

        [HttpGet("user/{userId}", Name = "GetCartsByUserId")]
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

        [HttpGet("search", Name = "AdvancedSearch")]
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

        [HttpPost(Name = "CreateCart")]
        public async Task<IActionResult> CreateAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("User Id was null"));
            var result = await _cartServices.CreateAsync(userId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Cart created successfully"));
            return BadRequest(ServiceResult<string>.FailureResult("Failed to create cart"));
        }

        [HttpPut(Name = "UpdateCart")]
        public async Task<IActionResult> UpdateAsync(string cartId, string userId)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("Cart Id or User Id was null"));
            var result = await _cartServices.UpdateAsync(cartId, userId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Cart updated successfully"));
            return BadRequest(ServiceResult<string>.FailureResult("Failed to update cart"));
        }

        [HttpDelete(Name = "DeleteCart")]
        public async Task<IActionResult> DeleteAsync(string cartId, string userId)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(userId)) return BadRequest(ServiceResult<string>.FailureResult("Cart Id or User Id was null"));
            var result = await _cartServices.DeleteAsync(cartId, userId);
            if (result) return Ok(ServiceResult<string>.SuccessResult("Cart deleted successfully"));
            return BadRequest(ServiceResult<string>.FailureResult("Failed to delete cart"));
        }
    }
}
