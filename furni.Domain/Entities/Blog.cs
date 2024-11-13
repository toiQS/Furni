using System.ComponentModel.DataAnnotations.Schema;

namespace furni.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string BlogName { get; set; } = string.Empty;

        public string UserIdCreated { get; set; }

        public virtual User User { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string URLImage { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
