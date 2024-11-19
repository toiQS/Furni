using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string ColorId { get; set; }
        public Color Color { get; set; }
        public string SizeId { get; set; }
        public Size Size { get; set; }
        public string URLImage { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
