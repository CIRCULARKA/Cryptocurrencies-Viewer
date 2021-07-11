using System;
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

		/// <summary>
		/// Pulls data from API to database
		///	Takes no effect if DB is empty
		/// </summary>
		public void RefreshCurrencyInfo()
		{
			if (_context.Currencies.Count() == 0) return;

			var newData = _provider.GetCurrencyFromRemoteServer();

			foreach (var currency in newData)
			{
				try
				{
					var target = _context.
						Currencies.
							First(c => c.CurrencyID == currency.CurrencyID);

					target.Price = currency.Price;
					target.MarketCapitalization = currency.MarketCapitalization;
					target.Last1HourDynamics = currency.Last1HourDynamics;
					target.Last24HoursDynamics = currency.Last24HoursDynamics;
					target.LastTimeUpdated = currency.LastTimeUpdated;

					_context.Currencies.Update(target);
				}
				catch (InvalidOperationException) { }
			}

			SaveChanges();
		}

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
