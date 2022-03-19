using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class FeeController : Controller
    {
        IFeeDepartmentRepo feeService;
        public FeeController(IFeeDepartmentRepo _feeService)
        {
            feeService = _feeService;
        }
        public IActionResult Index()
        {
            IEnumerable<FeeModel> fee = feeService.GetAllFee();
            return View(fee);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeeModel fee)
        {
            feeService.AddFee(fee);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            FeeModel fee = feeService.GetFeeById(id);
            return View(fee);
        }

        [HttpPost]
        public IActionResult Edit(FeeModel fee)
        {
            feeService.EditFee(fee);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            FeeModel fee = feeService.GetFeeById(id);
            return View(fee);
        }

        [HttpPost]
        public IActionResult Delete(FeeModel fee)
        {
            feeService.DeleteFee(fee);
            return RedirectToAction(nameof(Index));
        }
    }
}
