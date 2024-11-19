using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Address : BaseEntity
    {
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string FullName {  get; set; }
        public string Email {  get; set; }
        public string Phone {  get; set; }
        public string StreetAddress {  get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
