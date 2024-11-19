using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Order : BaseEntity
    {
        public double ShippingFee { get; set; }

        public double Total { get; set; }

        public OrderStatus Status { get; set; }
        
        public bool PaymentStatus { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DeliveryInformation DeliveryInformation { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        Confirmed,
        Unconfirmed,
        Canceled
    }
}
