using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using CurrencyViewer.Models;

namespace CurrencyViewer.CoinMarketApi
{
	public class CryptoCurrencyProvider : ICurrencyProvider<CryptoCurrency>
	{
		private ICurrencyDeserializer<CryptoCurrency> _deserializer;

		private UriBuilder _endpoint;

		private WebClient _client;

		private IApiProvider _apiProvider;

		public CryptoCurrencyProvider(string endpoint,
			IDictionary<string, string> parameters,
			ICurrencyDeserializer<CryptoCurrency> deserializer,
			IApiProvider apiProvider
		)
		{
			_client = new WebClient();
			_deserializer = deserializer;
			_endpoint = new UriBuilder(endpoint);
			_apiProvider = apiProvider;

			SetQueryForEndpoint(parameters);
			ConfigureWebClient();

			Request = _endpoint.Uri.AbsoluteUri;
		}

		public string Request { get; }

		public IEnumerable<CryptoCurrency> GetCurrencyFromRemoteServer()
		{
			try
			{
				var jsonData = _client.DownloadString(Request);
				return _deserializer.DeserializeJsonData(jsonData);
			}
			catch { throw new Exception("Wrong API key"); }
		}

		private void SetQueryForEndpoint(IDictionary<string, string> parameters)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			foreach (var pair in parameters)
			{
				query[pair.Key] = pair.Value;
			}

			_endpoint.Query = query.ToString();
		}

		private void ConfigureWebClient()
		{
			_client.Headers.Add(
				"X-CMC_PRO_API_KEY",
				_apiProvider.GetApiKey()
			);

			_client.Headers.Add(
				"Accepts",
				"application/json"
			);
		}
	}
}
