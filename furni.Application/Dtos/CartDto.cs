namespace furni.Application.Dtos;

public class CartDto
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public bool IsActive { get; set; }

    public List<CartDetailDto> CartDetails { get; set; } = [];
}
