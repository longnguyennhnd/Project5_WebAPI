using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Permissions
    {
        [Key]
        public int Pid { get; set; }
        public string Username { get; set; }
        public string FacultyId { get; set; }

        public virtual Faculties Faculty { get; set; }
        public virtual Accounts UsernameNavigation { get; set; }
    }
}
