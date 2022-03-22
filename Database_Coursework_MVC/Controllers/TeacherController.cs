using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Database_Coursework_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherRepo teacherService;
        public TeacherController(ITeacherRepo _teacherService)
        {
            teacherService = _teacherService;
        }
        public IActionResult Index()
        {
            IEnumerable<TeacherModel> teacher = teacherService.GetAllTeacher();
            return View(teacher);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherModel teacher)
        {
            teacherService.AddTeacher(teacher);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            TeacherModel teacher = teacherService.GetTeacherById(id);
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(TeacherModel teacher)
        {
            teacherService.EditTeacher(teacher);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            TeacherModel teacher = teacherService.GetTeacherById(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult Delete(int id, TeacherModel teacherModel)
        {
            try
            {
                TeacherModel teacher = teacherService.GetTeacherById(id);
                teacherService.DeleteTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
