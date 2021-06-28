using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CryptocurrenciesViewer.Models;

namespace CryptocurrenciesViewer
{
	public class HomeController : Controller
	{
		private IRepository _repository;

		private int _pageSize = 10;

		public HomeController(IRepository repo)
		{
			_repository = repo;
		}

		public IActionResult GetCryptocurrenciesList(int? pageIndex) =>
			View(
				viewName: "Cryptocurrencies",
				model: PaginatedList<CryptoCurrency>.Create(
					source: _repository.AllCurrency.AsQueryable(),
					pageIndex: pageIndex ?? 1,
					pageSize: _pageSize
				)
			);
	}
}
