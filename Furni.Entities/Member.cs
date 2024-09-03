using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furni.Entities
{
    public class Member
    {
        [Key]
        [Column(name:"Member Id")]
        public string MemberId { get; set; } = string.Empty;
        [Column(name:"First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Column(name:"Middle Name")]
        public string MiddleName { get; set; } = string.Empty ;
        [Column(name:"Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Column(name:"Full Name")]
        public string FullName {  get; set; } = string.Empty ;
        public string Position {  get; set; } = string.Empty;
        public string Summary {  get; set; } = string.Empty ;
        [Column(name:"URL Image")]
        public string URLImage {  get; set; } = string.Empty ;
    }
}
