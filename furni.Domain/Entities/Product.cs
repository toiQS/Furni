using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public float Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public float PriceSale { get; set; } = 0;

        public bool IsFeatured { get; set; } = false;

        public string Slug { get; set; }

        public Label Label { get; set; }

        public bool IsActive { get; set; }

        public string URLImage { get; set; } = string.Empty;

        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string BrandId { get; set; }

        public Brand Brand { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }

    public enum Label
    {
        Hot,
        New,
        NoLabel,
    }

    public enum Status
    {
        Published,
        Draft
    }
}
