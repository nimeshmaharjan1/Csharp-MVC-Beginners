using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepo _addressService;
        public AddressController (IAddressRepo addressService)
        {
            _addressService = addressService;
        }
        public IActionResult Index()
        {
            IEnumerable<AddressModel> address = _addressService.GetAllAddresses();
            return View(address);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddressModel address)
        {
            _addressService.AddAddress(address);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            AddressModel address = _addressService.GetAddressById(id);
            return View(address);
        }

        [HttpPost]
        public IActionResult Edit(AddressModel address)
        {
            _addressService.EditAddress(address);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            AddressModel address = _addressService.GetAddressById(id);
            return View(address);
        }

        // POST: DeleteTestController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AddressModel addressModel)
        {
            try
            {
                AddressModel address = _addressService.GetAddressById(id);
                _addressService.DeleteAddress(address);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
