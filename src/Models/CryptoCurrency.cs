using System;

namespace CryptocurrenciesViewer.Models
{
	public class CryptoCurrency : IModel
	{
		public string Name { get; set; }

		public decimal MarketCapitalization { get; set; }
	}
}
