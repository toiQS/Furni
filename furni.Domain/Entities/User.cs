using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class User : IdentityUser<String>
    {
        public ICollection<Blog>? Blogs { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        //public Cart Cart { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;
        public int Gender { get; set; } = 1;
        public DateTime? BirthDay { get; set; }
        public string ProfileImageUrl { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
