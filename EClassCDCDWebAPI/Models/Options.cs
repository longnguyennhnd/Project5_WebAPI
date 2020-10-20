using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Options
    {
        [Key]
        public int OptionId { get; set; }
        public int? QuestionId { get; set; }
        public int? OptionOrder { get; set; }
        public string Value { get; set; }
        public double Mark { get; set; }
        public virtual Questions Question { get; set; }
    }
}
