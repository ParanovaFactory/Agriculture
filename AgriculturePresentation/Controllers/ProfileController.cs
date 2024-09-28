using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

		public ProfileController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.Mail = values.Email;
			userEditViewModel.Phone = values.PhoneNumber;
			ViewBag.name = values.UserName;
			return View(userEditViewModel);
		}

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
			if (model.Password == model.ConfirmPassword) 
			{
                values.Email = model.Mail;
                values.PhoneNumber = model.Phone;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);

				var result = await _userManager.UpdateAsync(values);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
            }
            return View();
        }
    }
}
