using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Entities
{
    public class Blog
    {
        [Key]
        [Column(name:"Blog Id")]
        public string BlogId { get; set; } = string.Empty;
        [Column(name:"Blog Name")]
        public string BlogName { get; set; } = string.Empty ;
        [Column(name:"User Id Created")]
        [ForeignKey(nameof(Member))]
        public string UserIdCreated {  get; set; } = string.Empty ;
        public virtual Member Member { get; set; }  
        [Column(name:"Create At")]
        public DateTime CreateAt { get; set; }
        [Column(name:"Update At")]
        public DateTime UpdateAt { get; set; }
    }
}
