using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CryptocurrenciesViewer.Models;

namespace CryptocurrenciesViewer.Controllers
{
	public class IdentityController : Controller
	{
		private UserManager<User> _usersManager;
	}
}
