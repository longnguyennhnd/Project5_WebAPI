using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EClassCDCDWebAPI.Models
{
    public partial class UserRequests
    {
        [Key]
        public int RequestId { get; set; }
        public Guid Code { get; set; }
        public string Email { get; set; }
        public DateTime RequestTime { get; set; }
        public bool IsHandled { get; set; }
        public bool? IsFromStudent { get; set; }
    }
}
