using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var values = _addressService.GetListAll();
            return View(values);
        }

        //[HttpGet]
        //public IActionResult AddAddress()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddAddress(Address address)
        //{
        //    AddresValidator rules = new AddresValidator();
        //    ValidationResult result = rules.Validate(address);
        //    if (result.IsValid)
        //    {
        //        _addressService.Insert(address);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var value = _addressService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditAddress(Address address)
        {
            AddresValidator rules = new AddresValidator();
            ValidationResult result = rules.Validate(address);
            if (result.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        //public IActionResult DeleteAddress(int id)
        //{
        //    var value = _addressService.GetById(id);
        //    _addressService.Delete(value);
        //    return RedirectToAction("Index");
        //}
    }
}
