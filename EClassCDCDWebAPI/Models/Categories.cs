using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Plans = new HashSet<Plans>();
            Questions = new HashSet<Questions>();
        }
        [Key]
        public string CateId { get; set; }
        public string CateName { get; set; }

        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
