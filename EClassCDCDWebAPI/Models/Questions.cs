using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Questions
    {
        public Questions()
        {
            AnswerDetails = new HashSet<AnswerDetails>();
            Options = new HashSet<Options>();
        }

        [Key]
        public int QuestionId { get; set; }
        public string CateId { get; set; }
        public int? QuestionOrder { get; set; }
        public string TypeId { get; set; }
        public int? NumberOption { get; set; }
        public string Content { get; set; }
        public string Desciption { get; set; }
        public double? Mark { get; set; }
        public virtual Categories Cate { get; set; }

        public virtual Types Type { get; set; }

        public virtual ICollection<AnswerDetails> AnswerDetails { get; set; }

        public virtual ICollection<Options> Options { get; set; }
    }
}
