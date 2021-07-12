using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CurrencyViewer.Models;

namespace CurrencyViewer.Controllers
{
	public class HomeController : Controller
	{
		private IRepository _repository;

		private int _pageSize = 10;

		public HomeController(IRepository repo)
		{
			_repository = repo;
		}

		public IActionResult GetCryptocurrenciesList(int? pageIndex, string messageToUser)
		{
			if (User.Identity.IsAuthenticated)
			{
				try { _repository.LoadCurrencyFromServer(); }
				catch (ApiException) { }

				ViewData["messageToUser"] = messageToUser;

				return View(
					viewName: "Cryptocurrencies",
					model: PaginatedList<CryptoCurrency>.Create(
						source: _repository.AllCurrency.OrderByDescending(c => c.MarketCapitalization).AsQueryable(),
						pageIndex: pageIndex ?? 1,
						pageSize: _pageSize
					)
				);
			}
			else
				return RedirectToAction(
					controllerName: "Identity",
					actionName: "GetAuthorizationView"
				);
		}

		public IActionResult RefreshCurrencyList(int? pageIndex)
		{
			string message = "";

			try
			{
				_repository.RefreshCurrencyInfo();
			}
			catch (ApiException)
			{
				message = "Can't refresh data. Probably API key is wrong";
			}

			return RedirectToAction(
				actionName: nameof(GetCryptocurrenciesList),
				new { pageIndex = pageIndex, messageToUser = message }
			);
		}
	}
}
