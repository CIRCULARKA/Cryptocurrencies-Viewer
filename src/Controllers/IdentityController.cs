using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CurrencyViewer.Models;
using CurrencyViewer.ViewModels;

namespace CurrencyViewer.Controllers
{
	public class IdentityController : Controller
	{
		private UserManager<User> _usersManager;

		private SignInManager<User> _signInManager;

		public IdentityController(UserManager<User> usersManager,
			SignInManager<User> signInManager
		)
		{
			_usersManager = usersManager;
			_signInManager = signInManager;
		}

		public IActionResult GetRegistrationPage() =>
			View("Registration");

		[HttpPost]
		public async Task<IActionResult> RegisterUser(RegistrationViewModel model)
		{
			if (!ModelState.IsValid) return View("Registration", model);

			var newUser = new User {
				Email = model.Email,
				UserName = model.Email
			};

			var registrationResult = await _usersManager.
				CreateAsync(newUser, model.Password);

			if (!registrationResult.Succeeded)
			{
				foreach (var error in registrationResult.Errors)
					ModelState.AddModelError(string.Empty, error.Description);

				return View("Registration", model);
			}

			await _signInManager.SignInAsync(newUser, isPersistent: true);

			return RedirectToAction(
				actionName: "GetCryptocurrenciesList",
				controllerName: "Home"
			);
		}
	}
}
