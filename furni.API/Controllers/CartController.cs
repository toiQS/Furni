using furni.Application.Dtos;
using furni.Application.Interfaces.Management;
using Microsoft.AspNetCore.Mvc;

namespace furni.API.Controllers;

/// <summary>
/// Cart controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartManagement _cartManagement;

    public CartController(ICartManagement cartManagement)
    {
        _cartManagement = cartManagement;
    }

    /// <summary>
    /// Get cart by id
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>Task{ActionResult{BaseResponse{CartDto}}}</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<CartDto>>> GetByIdAsync(string id)
    {
        BaseResponse<CartDto> result = await _cartManagement.GetByIdAsync(id);

        return Ok(result);
    }
}
