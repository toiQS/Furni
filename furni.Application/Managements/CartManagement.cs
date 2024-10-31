using furni.Application.Interfaces.Management;
using furni.Entities;
using furni.Infrastructure.IServices;

namespace furni.Application.Management;

public class CartManagement : ICartManagement
{
    private readonly ICartServices _cartService;

    public CartManagement(ICartServices CartService)
    {
        _cartService = CartService;
    }

    public async Task<BaseResponse<Cart>> GetByIdAsync(string id)
    {
        Cart foundCart = await _cartService.GetByIdAsync(id);
        if (foundCart == null)
        {
            return new BaseResponse<Cart> { Message = "Cart is not found", Status = false };
        }

        return new BaseResponse<Cart> { Data = foundCart };
    }
}
