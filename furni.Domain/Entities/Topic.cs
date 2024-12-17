using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace furni.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public ICollection<Blog> Blogs { get; set; }
    }
}
