using System.ComponentModel.DataAnnotations;

namespace furni.Entities
{
	public class Brand
	{
		[Key]
		public string BrandId { get; set; } = string.Empty;
		[Required]
		public string BrandName { get; set; } 
		public string BrandDescription { get; set;} = string.Empty;
		[EmailAddress]
		public string BrandEmail { get;set;} = string.Empty;
		[Phone]
		public string BrandPhone { get; set; } = string.Empty;
		public ICollection<Product> Products { get; set; }
	}
}
