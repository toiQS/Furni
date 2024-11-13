using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public float Price { get; set; }

        public string URLImage { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public string BrandId { get; set; }

        public Brand Brand { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
