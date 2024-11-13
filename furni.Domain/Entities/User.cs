using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class User : IdentityUser<String>
    {
        public string FirstName { get; set; } = string.Empty;

        public ICollection<Blog>? Blogs { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public Cart Cart { get; set; }

        public string? MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
