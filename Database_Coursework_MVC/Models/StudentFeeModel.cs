﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Models
{
    public class StudentFeeModel
    {
        public int StudentId { get; set; }
        public int FeeId { get; set; }
        public string FeeName { get; set; }
        public int PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}