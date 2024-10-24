using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
	public class Order
	{
		[Key]
		public string OrderId { get; set; } = string.Empty;
		public string? CouponId { get; set; }
        public Coupon? Coupon { get; set; } = null;
		public double Total { get; set; }
		public bool Status { get; set; }
		[ForeignKey("UserId")]
		public string UserId { get; set; }
		public virtual User Id { get; set; }
		public DeliveryInformation DeliveryInformation { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
