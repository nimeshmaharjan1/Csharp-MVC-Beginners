using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Models
{
    public class TeacherModuleModel
    {
        public int TeacherId { get; set; }
        public int ModuleCode { get; set; }
        public string TeacherName { get; set; }
        public string ModuleName { get; set; }
        public int CreditHours { get; set; }

    }
}
