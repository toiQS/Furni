using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Entities
{
    public class User : IdentityUser<String>
    {
        
        [Column(name:"First Name")]
        public string FirstName { get; set; } = string.Empty;
        public ICollection<Blog>? Blogs {  get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Cart Cart { get; set; }
        [Column(name: "Middle Name")]
        public string? MiddleName { get; set; } = string.Empty;
        [Column(name: "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Column(name: "Full Name")]
        public string FullName { get; set; } = string.Empty;
        //public string Position { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        [Column(name: "URL Image")]
        public string URLImage { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
