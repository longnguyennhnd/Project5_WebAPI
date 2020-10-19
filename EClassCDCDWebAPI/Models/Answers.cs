using System;
using System.Collections.Generic;

namespace EClassCDCDWebAPI.Models
{
    public partial class Answers
    {
        public Answers()
        {
            AnswerDetails = new HashSet<AnswerDetails>();
        }

        public Guid AnswerId { get; set; }
        public string StudentId { get; set; }
        public int PlanId { get; set; }
        public DateTime Time { get; set; }

        public virtual Plans Plan { get; set; }
        public virtual ICollection<AnswerDetails> AnswerDetails { get; set; }
    }
}
