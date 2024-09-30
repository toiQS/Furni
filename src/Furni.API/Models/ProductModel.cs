using System.ComponentModel.DataAnnotations.Schema;

namespace Furni.API.Models
{
    public class ProductModel
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string URLImage { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
