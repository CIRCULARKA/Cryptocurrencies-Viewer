using System;
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

			try
			{
				foreach (var node in JObject.Parse(data)["data"])
				{
					var usdNode = node["quote"]["USD"];

					var currency = new CryptoCurrency() {
						ID = (int)node["id"],
						Name = (string)node["name"],
						Symbol = (string)node["symbol"],
						MarketCapitalization = (decimal)usdNode["market_cup"],
						Price = (decimal)usdNode["price"],
						Last1HourDynamics = (decimal)usdNode["percent_change_1h"],
						Last24HoursDynamics = (decimal)usdNode["percent_change_24h"]
					};

					result.Add(currency);
				}
			}
			catch
			{
				throw new Exception(
					"Incorrect data format. " +
					"Learn which data format must be provided for this deserializer here " +
					"https://pro.coinmarketcap.com/api/v1#operation/getV1CryptocurrencyListingsLatest"
				);
			}

			return result;
		}
	}
}
