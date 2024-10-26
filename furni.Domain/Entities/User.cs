using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Entities
{
    public class User : IdentityUser<String>
    {
        [Column(name: "First_Name")]
        public string FirstName { get; set; } = string.Empty;

        public ICollection<Blog>? Blogs { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public Cart Cart { get; set; }

        [Column(name: "Middle_Name")]
        public string? MiddleName { get; set; } = string.Empty;

        [Column(name: "Last_Name")]
        public string LastName { get; set; } = string.Empty;

        [Column(name: "Full_Name")]
        public string FullName { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
