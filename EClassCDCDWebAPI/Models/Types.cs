using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Types
    {
        public Types()
        {
            Questions = new HashSet<Questions>();
        }
        [Key]
        public string TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
