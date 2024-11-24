using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<Blog>? Blogs { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public List<Address>? Addresses { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        //public Cart Cart { get; set; }

        public string FullName { get; set; } = string.Empty;
        public bool? Status {  get; set; } = false;
        public string? ProfileImageUrl { get; set; }
        public string? Image { get; set; }
        public int? Gender { get; set; } = 1;
        public DateTime? BirthDay { get; set; }
        public DateTime JoinTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
