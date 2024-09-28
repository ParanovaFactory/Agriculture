using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contacService;

        public ContactController(IContactService contacService)
        {
            _contacService = contacService;
        }

        public IActionResult Index()
        {
            var values = _contacService.GetListAll();
            return View(values);
        }

        //[HttpGet]
        //public IActionResult AddContact()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddContact(Contact contact)
        //{
        //    contact.Date = DateTime.Parse(DateTime.Now.ToString());

        //    ContactValidator rules = new ContactValidator();
        //    ValidationResult result = rules.Validate(contact);
        //    if (result.IsValid)
        //    {
        //        _contacService.Insert(contact);
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

        //[HttpGet]
        //public IActionResult EditContact(int id)
        //{
        //    var value = _contacService.GetById(id);
        //    return View(value);
        //}

        //[HttpPost]
        //public IActionResult EditContact(Contact contact)
        //{
        //    contact.Date = DateTime.Parse(DateTime.Now.ToString());

        //    ContactValidator rules = new ContactValidator();
        //    ValidationResult result = rules.Validate(contact);
        //    if (result.IsValid)
        //    {
        //        _contacService.Update(contact);
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

        public IActionResult DeleteContact(int id)
        {
            var value = _contacService.GetById(id);
            _contacService.Delete(value);
            return RedirectToAction("Index");
        }

        public IActionResult MessageDetails(int id)
        {
            var value = _contacService.GetById(id);
            return View(value);
        }
    }
}
