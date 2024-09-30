using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Data
{
    public class User : IdentityUser
    {
        [Column(name:"Member Id")]
        public string? MemberId { get; set; } = string.Empty;
    }
}
