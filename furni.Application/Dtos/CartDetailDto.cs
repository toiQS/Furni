namespace furni.Application.Dtos;

public class CartDetailDto
{
    public string Id { get; set; }

    public int Quantity { get; set; }

    public float Total { get; set; }

    public ProductDto Product { get; set; }
}
