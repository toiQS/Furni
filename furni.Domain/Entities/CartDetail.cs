namespace furni.Entities
{
    public class CartDetail : BaseEntity
    {
        public string OrderDetailId { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public float Total { get; set; }

        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
