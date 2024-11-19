namespace furni.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string ProductVariantId { get; set; }

        public string OrderId { get; set; }

        public double ProductPrice { get; set; }

        public double Quantity { get; set; }

        public ProductVariant ProductVariant { get; set; }

        public Order Order { get; set; }
    }
}
