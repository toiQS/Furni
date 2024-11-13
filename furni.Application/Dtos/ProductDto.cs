namespace furni.Application.Dtos;

public class ProductDto
{
    public string ProductName { get; set; } = string.Empty;

    public float Price { get; set; }

    public string URLImage { get; set; } = string.Empty;

    public string BrandId { get; set; }

    public string CategoryId { get; set; }
}
