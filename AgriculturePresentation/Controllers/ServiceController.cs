using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var values = _service.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            ServiceValidator serviceValidator = new ServiceValidator();
            ValidationResult result = serviceValidator.Validate(service);
            if (result.IsValid)
            {

                _service.Insert(service);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var value = _service.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            ServiceValidator serviceValidator = new ServiceValidator();
            ValidationResult result = serviceValidator.Validate(service);
            if (result.IsValid)
            {

                _service.Update(service);
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

        public IActionResult DeleteService(int id)
        {
            var value = _service.GetById(id);
            _service.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
