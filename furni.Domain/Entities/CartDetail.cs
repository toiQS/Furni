namespace furni.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        public string ProductVariantId { get; set; }

        public ProductVariant ProductVariant { get; set; }

        public int Quantity { get; set; }

        public float Total { get; set; }

        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
