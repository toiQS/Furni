using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Order : BaseEntity
    {
        public double ShippingFee { get; set; }
        public double Total { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int PaymentMethod { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool PaymentStatus { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string ShippingMethodId { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        Confirmed,
        Unconfirmed,
        Canceled
    }
}
