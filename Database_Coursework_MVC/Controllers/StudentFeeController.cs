using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class StudentFeeController : Controller
    {
        IStudentFeeRepo studentFeeService;
        public StudentFeeController(IStudentFeeRepo _studentFeeService)
        {
            studentFeeService = _studentFeeService;
        }
        public IActionResult Index()
        {
            IEnumerable<StudentFeeModel> studentList = studentFeeService.GetAllStudents();
            return View(studentList);
        }
        public IActionResult StudentFeeDetails(int id)
        {
            IEnumerable<StudentFeeModel> studentFeeList = studentFeeService.GetAllFeesOfStudent(id);
            return View(studentFeeList);
        }
    }
}
