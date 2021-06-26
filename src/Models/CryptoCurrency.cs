using Newtonsoft.Json;

namespace CryptocurrenciesViewer.Models
{
	public class CryptoCurrency : IModel
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public string Symbol { get; set; }

		public decimal Price { get; set; }

		[JsonProperty(PropertyName = "market_cap")]
		public decimal MarketCapitalization { get; set; }

		[JsonProperty(PropertyName = "percent_change_24h")]
		public decimal Last24HoursDynamics { get; set; }

		[JsonProperty(PropertyName = "percent_change_1h")]
		public decimal Last1HourDynamics { get; set; }
	}
}
