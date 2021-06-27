using System.Collections.Generic;

namespace CryptocurrenciesViewer.CoinMarketApi
{
	public interface ICurrencyDeserializer<T>
	{
		IEnumerable<T> DeserializeJsonData(string jsonData);
	}
}
