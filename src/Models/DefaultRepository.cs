using System.Linq;
using System.Collections.Generic;
using CryptocurrenciesViewer.CoinMarketApi;

namespace CryptocurrenciesViewer.Models
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
		}

		public void RefreshData()
		{
			if (_context.Currencies.Count() > 0)
			{
				_context.Currencies.UpdateRange(
					_provider.GetCurrencyFromRemoteServer()
				);
			}
		}

		public IEnumerable<CryptoCurrency> AllCurrency =>
			_context.Currencies.ToList();
	}
}
