using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Models
{
    public class StudentFeeModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int FeeId { get; set; }
        public string FeeName { get; set; }
        public string Paid { get; set; }
        public int PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; } 
    }
}
