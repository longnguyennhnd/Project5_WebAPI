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

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Departments Department { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Plans> Plans { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
