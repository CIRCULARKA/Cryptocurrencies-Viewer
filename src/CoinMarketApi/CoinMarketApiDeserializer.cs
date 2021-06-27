using System.Collections.Generic;
using CryptocurrenciesViewer.Models;
using Newtonsoft.Json.Linq;

namespace CryptocurrenciesViewer.CoinMarketApi
{
	public class CoinMarketApiDeserializer
	{
		public IEnumerable<CryptoCurrency> DeserializeJsonData(string data)
		{
			var result = new List<CryptoCurrency>();

			foreach (var node in JObject.Parse(data)["data"])
			{
				var usdNode = node["quote"]["USD"];

				var currency = new CryptoCurrency() {
					ID = (int)node["id"],
					Name = (string)node["name"],
					MarketCapitalization = (decimal)usdNode["market_cup"],
					Price = (decimal)usdNode["price"],
					Last1HourDynamics = (decimal)usdNode["percent_change_1h"],
					Last24HoursDynamics = (decimal)usdNode["percent_change_24h"]
				};

				result.Add(currency);
			}

			return result;
		}
	}
}
