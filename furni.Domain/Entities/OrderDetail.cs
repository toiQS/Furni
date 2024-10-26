namespace furni.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string ProductId { get; set; }

        public string OrderId { get; set; }

        public double Quantity { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
