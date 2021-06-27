using System;
using System.Collections.Generic;
using CryptocurrenciesViewer.Models;
using Newtonsoft.Json.Linq;

namespace CryptocurrenciesViewer.CoinMarketApi
{
	public class DataDeserializer
	{
		public IEnumerable<CryptoCurrency> DeserializeJsonData(string data)
		{
			var result = new List<CryptoCurrency>();

			try
			{
				foreach (var node in JObject.Parse(data)["data"])
				{
					var usdNode = node["quote"]["USD"];

					var currency = new CryptoCurrency();

					currency.ID = (int)node["id"];
					currency.Name = (string)node["name"];
					currency.Symbol = (string)node["symbol"];
					currency.MarketCapitalization = (decimal)usdNode["market_cap"];
					currency.Price = (decimal)usdNode["price"];
					currency.Last1HourDynamics = (decimal)usdNode["percent_change_1h"];
					currency.Last24HoursDynamics = (decimal)usdNode["percent_change_24h"];

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
