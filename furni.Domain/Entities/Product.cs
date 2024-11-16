using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Column(name: "Product_Name")]
        public string ProductName { get; set; } = string.Empty;

        public float Price { get; set; }

        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;

        [Column(name: "Is_Active")]
        public bool IsActive { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public string BrandId { get; set; }

        public Brand Brand { get; set; }
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
