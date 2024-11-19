using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string TopicName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Blog> Blogs { get; set; }
    }
}
