using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Entities
{
    public class Cart
    {
        [Key]
        [Column(name:"Cart Id")]
        public string CartId { get; set; } = string.Empty;
        public bool Status { get; set; }
        [Column(name:"User Id")]
        public string UserId { get; set; } = string.Empty ;
        public List<Item> Items = new List<Item>();
    }
}
