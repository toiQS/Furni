using System.ComponentModel.DataAnnotations.Schema;

namespace Furni.API.Models
{
    public class MemberModel
    {
        public string MemberId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string URLImage { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
