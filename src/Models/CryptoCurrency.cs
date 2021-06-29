using System;
using Newtonsoft.Json;

namespace CurrencyViewer.Models
{
	public class CryptoCurrency : IModel
	{
		public int ID { get; set; }

		public int CurrencyID { get; set; }

		public string Name { get; set; }

		public string Symbol { get; set; }

		public decimal Price { get; set; }

		public decimal MarketCapitalization { get; set; }

		public decimal Last24HoursDynamics { get; set; }

		public decimal Last1HourDynamics { get; set; }

		public DateTime LastTimeUpdated { get; set; }
	}
}
