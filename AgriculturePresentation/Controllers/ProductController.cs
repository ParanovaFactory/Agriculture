using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var v = _productService.GetListAll();
            return View(v);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator rules = new ProductValidator();
            ValidationResult result = rules.Validate(product);
            if (result.IsValid)
            {
                _productService.Insert(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var v =_productService.GetById(id);
            return View(v);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            ProductValidator rules = new ProductValidator();
            ValidationResult result = rules.Validate(product);
            if (result.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult DeleteProduct(int id)
        {
            var v = _productService.GetById(id);
            _productService.Delete(v);
            return RedirectToAction("Index");
        }
    }
}
