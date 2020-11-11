using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Classes
    {
        public Classes()
        {
            Plans = new HashSet<Plans>();
            Students = new HashSet<Students>();
        }
        [Key]
        public string ClassId { get; set; }
        public string FacultyId { get; set; }
        public int? Total { get; set; }
        public string Year { get; set; }
        public string Period { get; set; }
        public string EmployeeId { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
