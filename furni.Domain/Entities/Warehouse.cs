using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
    public class Warehouse : BaseEntity
    {
        [Required]
        public double Quantity { get; set; }

        [Required]
        public double Limit { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
