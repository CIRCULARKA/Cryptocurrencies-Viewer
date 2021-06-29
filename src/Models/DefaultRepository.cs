using System.Linq;
using System.Collections.Generic;
using CurrencyViewer.CoinMarketApi;

namespace CurrencyViewer.Models
{
	public class DefaultRepository : IRepository
	{
		DbContextBase _context;

		ICurrencyProvider<CryptoCurrency> _provider;

		public DefaultRepository(DbContextBase context,
			ICurrencyProvider<CryptoCurrency> provider
		)
		{
			_context = context;
			_provider = provider;

			LoadCurrencyFromServer();
		}

		public IEnumerable<CryptoCurrency> AllCurrency =>
			_context.Currencies.ToList();

		public void SaveChanges() =>
			_context.SaveChanges();

		private void LoadCurrencyFromServer()
		{
			if (_context.Currencies.Count() == 0)
			{
				_context.Currencies.AddRange(
					_provider.GetCurrencyFromRemoteServer()
				);

				SaveChanges();
			}
		}
	}
}
