using Microsoft.AspNetCore.Mvc;

namespace CryptocurrenciesViewer
{
	public class HomeController : Controller
	{
		public IActionResult GetCryptocurrenciesList()
		{
			return View("Cryptocurrencies");
		}
	}
}
