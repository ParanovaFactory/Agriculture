using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _team;

        public TeamController(ITeamService team)
        {
            _team = team;
        }

        public IActionResult Index()
        {
            var values =  _team.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            TeamValidator teamValidator = new TeamValidator();
            ValidationResult result = teamValidator.Validate(team);
            if (result.IsValid)
            {
                _team.Insert(team);
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
        public IActionResult EditTeam(int id)
        {
            var value = _team.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            TeamValidator teamValidator = new TeamValidator();
            ValidationResult result = teamValidator.Validate(team);
            if (result.IsValid)
            {
                _team.Update(team);
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

        public IActionResult DeleteTeam(int id)
        {
            var value = _team.GetById(id);
            _team.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
