using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EClassCDCDWebAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
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

        [ForeignKey(nameof(ClassId))]
        public virtual Classes Class { get; set; }
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
