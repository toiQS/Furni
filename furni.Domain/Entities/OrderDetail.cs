using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
	public class OrderDetail
	{
		[Key]
		public string OrderDetailId { get; set; }
		public string ProductId { get; set; }
		public string OrderId { get; set; }
		public double Quantity { get; set; }
		public Product Product { get; set; }
		public Order Order { get; set; }
	}
}
