using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[Required]
		public string CategoryName { get; set; } = string.Empty;
		public string CategoryDescription { get; set; } = string.Empty ;
		public ICollection<Product> Products { get; set; }
	}
}
