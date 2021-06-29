using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CurrencyViewer.Models;

namespace CurrencyViewer.Controllers
{
	public class IdentityController : Controller
	{
		private UserManager<User> _usersManager;
	}
}
