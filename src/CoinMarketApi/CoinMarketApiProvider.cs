using System.IO;

namespace CryptocurrenciesViewer.CoinMarketApi
{
	public class CoinMarketApiProvider
	{
		private StreamReader _reader;

		public CoinMarketApiProvider(StreamReader reader) =>
			_reader = reader;

		public string GetApiKey()
		{
			try { return _reader.ReadLine(); }
			catch { return ""; }
		}
	}
}
