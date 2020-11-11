using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Plans
    {
        public Plans()
        {
            Answers = new HashSet<Answers>();
        }

        [Key]
        public int PlanId { get; set; }
        public string ClassId { get; set; }
        public string SubjectId { get; set; }
        public string EmployeeId { get; set; }
        public string CateId { get; set; }
        public string Year { get; set; }
        public int Semester { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? ActiveDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsCheck { get; set; }
        public bool? HasMark { get; set; }
        public DateTime? MarkDate { get; set; }
        public string MarkCode { get; set; }
        public string Username { get; set; }


        public virtual Categories Cate { get; set; }

        public virtual Classes Class { get; set; }

        public virtual Employees Employee { get; set; }

        public virtual Subjects Subject { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}
