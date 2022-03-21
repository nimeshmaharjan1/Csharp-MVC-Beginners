using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepo studentService;
        public StudentController(IStudentRepo _studentService)
        {
            studentService = _studentService;
        }
        public IActionResult Index()
        {
            IEnumerable<StudentModel> student = studentService.GetAllStudent();
            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            studentService.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            StudentModel student = studentService.GetStudentById(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(StudentModel student)
        {
            studentService.EditStudent(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            StudentModel student = studentService.GetStudentById(id);
            studentService.DeleteStudent(student);
            return RedirectToAction(nameof(Index));
            //   return View(student);
        }

        [HttpPost]
        public IActionResult Delete(StudentModel student)
        {
            studentService.DeleteStudent(student);
            return RedirectToAction(nameof(Index));
        }
    }
}
