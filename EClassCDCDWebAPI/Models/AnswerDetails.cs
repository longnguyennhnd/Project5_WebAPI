using System;
using System.Collections.Generic;

namespace EClassCDCDWebAPI.Models
{
    public partial class AnswerDetails
    {
        public Guid AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Value { get; set; }

        public virtual Answers Answer { get; set; }
        public virtual Questions Question { get; set; }
    }
}
