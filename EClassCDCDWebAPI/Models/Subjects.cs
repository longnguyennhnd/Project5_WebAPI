using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Plans = new HashSet<Plans>();
            Scores = new HashSet<Scores>();
        }
        [Key]
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? Credit { get; set; }
        public string DepartmentId { get; set; }
        public virtual Departments Department { get; set; }
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
