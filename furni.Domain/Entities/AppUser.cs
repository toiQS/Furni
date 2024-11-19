using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class AppUser : IdentityUser<String>
    {
        public ICollection<Blog>? Blogs { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public List<Address> Addresses { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        //public Cart Cart { get; set; }

        public string FullName { get; set; } = string.Empty;
        public bool? Status {  get; set; } = false;
        public string URLImage { get; set; } = string.Empty;
        public int? Gender { get; set; } = 1;
        public DateTime? BirthDay { get; set; }
        public DateTime JoinTime { get; set; } = DateTime.Now;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
