using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class StudentAssignmentController : Controller
    {
        IStudentAssignmentRepo studentAssignmentService;
        public StudentAssignmentController(IStudentAssignmentRepo _studentAssignmentService)
        {
            studentAssignmentService = _studentAssignmentService;
        }
        public IActionResult Index()
        {
            IEnumerable<StudentAssignmentModel> studentList = studentAssignmentService.GetAllStudents();
            return View(studentList);
        }
        public IActionResult StudentAssignmentDetails(int id)
        {
            IEnumerable<StudentAssignmentModel> studentFeeList = studentAssignmentService.GetAssignmentResultOfStudent(id);
            return View(studentFeeList);
        }
    }
}
