using System.Collections.Generic;

namespace CurrencyViewer.Models
{
	public interface IRepository
	{
		IEnumerable<CryptoCurrency> AllCurrency { get; }

		void SaveChanges();
	}
}
