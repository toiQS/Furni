namespace furni.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public double ProductPrice { get; set; }

        public double Quantity { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string OrderId { get; set; }
    }
}
