using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Entities
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; } = string.Empty;
		[ForeignKey("UserId")]
		public string UserId { get; set; }
		public virtual User Id { get; set; }
        public bool IsActive { get; set; }

		public List<CartDetail> CartDetails = new List<CartDetail>();
    }
}
