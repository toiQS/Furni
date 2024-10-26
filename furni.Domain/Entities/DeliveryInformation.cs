using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class DeliveryInformation : BaseEntity
    {
        public string OrderId { get; set; }

        public Order Order { get; set; }

        [Column(name: "First_Name")]
        [Required]
        public string FirstName { get; set; }

        [Column(name: "Last_Name")]
        [Required]
        public string LastName { get; set; }

        [Column(name: "Company_Name")]
        public string? CompanyName { get; set; } = string.Empty;

        [Column(name: "Street_Address")]
        [Required]
        public string StreetAddress { get; set; }

        [Column(name: "Address_Detail")]
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
