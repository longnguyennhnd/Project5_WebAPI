using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Classes = new HashSet<Classes>();
            Plans = new HashSet<Plans>();
        }
        [Key]
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public string FullName { get; set; }
        public bool? Gender { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Departments Department { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Classes> Classes { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Plans> Plans { get; set; }
    }
}
