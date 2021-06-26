using System;

namespace CryptocurrenciesViewer.Models
{
	public class CryptoCurrency : IModel
	{
		public string Name { get; set; }

		public string Symbol { get; set; }

		public decimal MarketCapitalization { get; set; }
	}
}
