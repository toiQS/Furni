using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
	public class Warehouse
	{
		[Key]
		public string WarehouseId { get; set; }
		[Required]
		public double Quantity { get; set; }
		[Required]
		public double Limit { get; set; }
		public string ProductId { get; set; }
		public Product Product { get; set; }
	}
}
