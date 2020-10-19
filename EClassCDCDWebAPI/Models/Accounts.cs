using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Permissions = new HashSet<Permissions>();
        }
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}
