using System.Collections.Generic;

namespace CryptocurrenciesViewer.CoinMarketApi
{
	public interface ICurrencyProvider<T>
	{
		IEnumerable<T> GetCurrencyFromRemoteServer();
	}
}
