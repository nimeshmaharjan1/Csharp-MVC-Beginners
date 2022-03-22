using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepo departmentService;
        public DepartmentController(IDepartmentRepo _departmentService)
        {
            departmentService = _departmentService;
        }
        public IActionResult Index()
        {
            IEnumerable<DepartmentModel> department = departmentService.GetAllDepartment();
            return View(department);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentModel department)
        {
            departmentService.AddDepartment(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            DepartmentModel department = departmentService.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentModel department)
        {
            departmentService.EditDepartment(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            DepartmentModel department = departmentService.GetDepartmentById(id);
            //departmentService.DeleteFee(department);
            //return RedirectToAction(nameof(Index));
            return View(department);
        }
        [HttpPost]
        public ActionResult Delete(int id, DepartmentModel departmentModel)
        {
            try
            {
                DepartmentModel department = departmentService.GetDepartmentById(id);
                departmentService.DeleteDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
