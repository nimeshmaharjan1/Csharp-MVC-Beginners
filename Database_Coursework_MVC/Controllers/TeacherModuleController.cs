using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class TeacherModuleController : Controller
    {
        ITeacherModuleRepo teacherModuleService;
        public TeacherModuleController(ITeacherModuleRepo _teacherModuleService)
        {
            teacherModuleService = _teacherModuleService;
        }
        public IActionResult Index()
        {
            IEnumerable<TeacherModuleModel> teacherModule = teacherModuleService.GetAllTeacher();
            return View(teacherModule);
        }
        public IActionResult TeacherDetails(int id)
        {
            IEnumerable<TeacherModuleModel> teacherModule = teacherModuleService.GetAllModulesOfTeacher(id);
            return View(teacherModule);
        }
    }
}
