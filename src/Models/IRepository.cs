using System.Collections.Generic;

namespace CryptocurrenciesViewer.Models
{
	public interface IRepository
	{
		void RefreshData();

		IEnumerable<CryptoCurrency> AllCurrency { get; }

		void SaveChanges();
	}
}
