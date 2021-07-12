using System.IO;
using System.Collections.Generic;
using CurrencyViewer.CoinMarketApi;

namespace CurrencyViewer.Models.Factories
{
	public class RepositoryFactory
	{
		private string _currencyEndpoint =
			"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

		public RepositoryFactory() { }

		public DefaultRepository CreateDefaultRepository() =>
			new DefaultRepository(
				new DefaultDbContext(),
				new CryptoCurrencyProvider(
						_currencyEndpoint,
						new Dictionary<string, string> {
					},
					new CryptoCurrencyDeserializer(),
					new ApiProvider(
						new StreamReader(
							new FileStream(
								Directory.
									GetCurrentDirectory() +
									"\\src\\api.txt",
								FileMode.OpenOrCreate
							)
						)
					)
				)
			);
	}
}
