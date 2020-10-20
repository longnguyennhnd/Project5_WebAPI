using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EClassCDCDWebAPI.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public List<OptionViewModel> options { get; set; }
    }
}
