using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Scores
    {
        [Key]
        public int ScoreId { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public decimal FinalScore { get; set; }
        public string Details { get; set; }
        public string Note { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? PlanId { get; set; }
        public virtual Students Student { get; set; }
        public virtual Subjects Subject { get; set; }
        public virtual Plans Plan { get; set; }
    }
}
