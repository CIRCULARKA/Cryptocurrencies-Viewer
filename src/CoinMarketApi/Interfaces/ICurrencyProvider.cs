using System.Collections.Generic;

namespace CurrencyViewer.CoinMarketApi
{
	public interface ICurrencyProvider<T>
	{
		IEnumerable<T> GetCurrencyFromRemoteServer();
	}
}
