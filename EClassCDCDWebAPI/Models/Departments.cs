using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Accounts = new HashSet<Accounts>();
            Employees = new HashSet<Employees>();
            Subjects = new HashSet<Subjects>();
        }
        [Key]
        public string DepartmentId { get; set; }
        public string FacultyId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Faculties Faculty { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Accounts> Accounts { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Employees> Employees { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Subjects> Subjects { get; set; }
    }
}
