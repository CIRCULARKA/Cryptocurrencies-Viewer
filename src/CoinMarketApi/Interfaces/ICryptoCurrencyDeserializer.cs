using System.Collections.Generic;

namespace CurrencyViewer.CoinMarketApi
{
	public interface ICurrencyDeserializer<T>
	{
		IEnumerable<T> DeserializeJsonData(string jsonData);
	}
}
