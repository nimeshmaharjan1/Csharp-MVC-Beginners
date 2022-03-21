using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Models
{
    public class StudentAssignmentModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ModuleCode { get; set; }
        public string AssignmentType { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
    }
}
