using furni.Application.Dtos;
using furni.Application.Interfaces.Management;
using furni.Domain.Entities;
using furni.Infrastructure.IServices;
using Mapster;
using Microsoft.Extensions.Logging;

namespace furni.Application.Management;

public class CartManagement : ICartManagement
{
    private readonly ICartServices _cartService;
    private readonly ILogger<CartManagement> _logger;

    public CartManagement(ICartServices CartService, ILogger<CartManagement> logger)
    {
        _cartService = CartService;
        _logger = logger;
    }

    public async Task<BaseResponse<CartDto>> GetByIdAsync(string id)
    {
        try
        {
            Cart foundCart = await _cartService.GetByIdAsync(id);
            if (foundCart == null)
            {
                throw new Exception("Cart is not found");
            }

            CartDto result = foundCart.Adapt<CartDto>();
            return new BaseResponse<CartDto> { Data = result };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Message: {ex.Message}");
            return new BaseResponse<CartDto> { Message = ex.Message, Status = false };
        }
    }
}
