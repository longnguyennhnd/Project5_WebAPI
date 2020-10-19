using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Students
    {
        public Students()
        {
            Scores = new HashSet<Scores>();
        }
        [Key]
        public string StudentId { get; set; }
        public string ClassId { get; set; }
        public string FullName { get; set; }
        public bool? Gender { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public virtual Classes Class { get; set; }
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
