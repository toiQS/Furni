using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class Order : BaseEntity
    {
        public string? CouponId { get; set; }

        public Coupon? Coupon { get; set; } = null;

        public double Total { get; set; }

        public bool Status { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DeliveryInformation DeliveryInformation { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
