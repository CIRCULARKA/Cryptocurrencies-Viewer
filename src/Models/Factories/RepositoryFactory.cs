using System.IO;
using System.Collections.Generic;
using CryptocurrenciesViewer.CoinMarketApi;

namespace CryptocurrenciesViewer.Models.Factories
{
	public abstract class RepositoryFactory
	{
		private string _currencyEndpoint =
			"https://pro.coinmarketcap.com/api/v1/cryptocurrency/listings/latest";

		public RepositoryFactory() { }

		public IRepository CreateDefaultRepository() =>
			new DefaultRepository(
				new DefaultDbContext(),
				new CryptoCurrencyProvider(
					_currencyEndpoint,
					new Dictionary<string, string> {
						{ "limit", "10" }
					},
					new CryptoCurrencyDeserializer(),
					new ApiProvider(
						new StreamReader(
							Directory.
								GetParent(
									Directory.GetCurrentDirectory()
								).Parent.Parent.FullName
						)
					)
				)
			);
	}
}
