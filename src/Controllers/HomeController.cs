using Microsoft.AspNetCore.Mvc;
using CryptocurrenciesViewer.Models;
using CryptocurrenciesViewer.Models.Factories;

namespace CryptocurrenciesViewer
{
	public class HomeController : Controller
	{
		private IRepository _repository;

		public HomeController()
		{
			_repository = new RepositoryFactory().
				CreateDefaultRepository();
		}

		public IActionResult GetCryptocurrenciesList()
		{
			_repository.RefreshData();
			_repository.SaveChanges();

			return View(
				viewName: "Cryptocurrencies",
				model: _repository.AllCurrency
			);
		}
	}
}
