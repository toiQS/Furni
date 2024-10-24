using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace furni.Entities
{
	public class DeliveryInformation
	{
		[Key]
		public string DeliverId { get; set; }
		public string OrderId {  get; set; }
		public Order Order { get; set; }
		[Column(name: "First Name")]
		[Required]
		public string FirstName { get; set; }
		[Column(name: "Last Name")]
		[Required]
		public string LastName { get; set; }
		[Column(name: "Company Name")]
		public string? CompanyName { get; set; } = string.Empty;
		[Column(name: "Street Address")]
		[Required]
		public string StreetAddress { get; set; }
		[Column(name: "Address Detail")]
		public string? AddressDetail { get; set; } = string.Empty;
		[Required]
		public string State { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Posta { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		public string? OrderNote { get; set; } = string.Empty;
	}
}
