using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Faculties
    {
        public Faculties()
        {
            Departments = new HashSet<Departments>();
            Permissions = new HashSet<Permissions>();
        }
        [Key]
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Departments> Departments { get; set; }

        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}
