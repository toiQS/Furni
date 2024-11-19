using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public float Price { get; set; }

        public string Description { get; set; }

        public float PriceSale { get; set; }

        public string Slug { get; set; }

        public Label Label { get; set; }

        public bool IsActive { get; set; }

        public Status Status { get; set; }

        public string BrandId { get; set; }

        public Brand Brand { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public ProductVariant ProductVariant { get; set; }
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
