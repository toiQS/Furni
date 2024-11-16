using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class User : IdentityUser<String>
    {

        public ICollection<Blog>? Blogs { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public Cart Cart { get; set; }

        [Column(name: "Full_Name")]
        public string FullName { get; set; } = string.Empty;

        [Column(name: "URL_Image")]
        public string URLImage { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
