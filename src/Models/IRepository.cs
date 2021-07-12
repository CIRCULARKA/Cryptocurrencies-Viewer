using System.Collections.Generic;

namespace CurrencyViewer.Models
{
	public interface IRepository
	{
		IEnumerable<CryptoCurrency> AllCurrency { get; }

		/// <summary>
		/// Refreshes data via API in database
		///	Takes no effect if DB is empty.
		/// </summary>
		void RefreshCurrencyInfo();

		/// <summary>
		/// Populates DB with data from server via API
		/// if DB is empty.
		/// Takes no effect if DB already has data.
		/// Use RefreshCurrencyInfo method if DB already has data.
		/// </summary>
		void LoadCurrencyFromServer();

		void SaveChanges();
	}
}
