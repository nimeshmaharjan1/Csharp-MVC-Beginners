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
        private IAddressRepo addressService;
        public AddressController (IAddressRepo _addressService)
        {
            addressService = _addressService;
        }
        public IActionResult Index()
        {
            IEnumerable<AddressModel> address = addressService.GetAllAddresses();
            return View(address);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddressModel address)
        {
            addressService.AddAddress(address);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            AddressModel address = addressService.GetAddressById(id);
            return View(address);
        }

        [HttpPost]
        public IActionResult Edit(AddressModel address)
        {
            addressService.EditAddress(address);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            AddressModel address = addressService.GetAddressById(id);
            addressService.DeleteAddress(address);
            return RedirectToAction(nameof(Index));
            //return View(address);
        }

        [HttpPost]
        public IActionResult Delete(AddressModel address)
        {
            addressService.DeleteAddress(address);
            return RedirectToAction(nameof(Index));
        }
    }
}
