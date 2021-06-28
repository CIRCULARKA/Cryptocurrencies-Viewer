using System.Collections.Generic;

namespace CryptocurrenciesViewer.Models
{
	public interface IRepository
	{
		IEnumerable<CryptoCurrency> AllCurrency { get; }

		void SaveChanges();
	}
}
