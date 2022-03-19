using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class ModuleController : Controller
    {
        IModuleRepo moduleService;
        public ModuleController (IModuleRepo _moduleService)
        {
            moduleService = _moduleService;
        }
        public IActionResult Index()
        {
            IEnumerable<ModuleModel> module = moduleService.GetAllModules();
            return View(module);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ModuleModel module)
        {
            moduleService.AddModule(module);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            ModuleModel module = moduleService.GetModuleById(id);
            return View(module);
        }

        [HttpPost]
        public IActionResult Edit(ModuleModel module)
        {
            moduleService.EditModule(module);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            ModuleModel module = moduleService.GetModuleById(id);
            return View(module);
        }

        [HttpPost]
        public IActionResult Delete(ModuleModel module)
        {
            moduleService.DeleteModule(module);
            return RedirectToAction(nameof(Index));
        }
    }
}
