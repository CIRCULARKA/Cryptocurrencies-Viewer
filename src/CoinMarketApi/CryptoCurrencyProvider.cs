using System;
using System.Net;
using System.Web;
using System.Collections.Generic;
using CryptocurrenciesViewer.Models;

namespace CryptocurrenciesViewer.CoinMarketApi
{
	public class CryptoCurrencyProvider
	{
		private DataDeserializer _deserializer;

		private UriBuilder _endpoint;

		private WebClient _client;

		private ApiProvider _apiProvider;

		public CryptoCurrencyProvider(string endpoint,
			IDictionary<string, string> parameters,
			DataDeserializer deserializer,
			ApiProvider apiProvider
		)
		{
			_deserializer = deserializer;
			_endpoint = new UriBuilder(endpoint);

			SetQueryForEndpoint(parameters);
			ConfigureWebClient();

			Request = _endpoint.ToString();
		}

		public string Request { get; }

		public IEnumerable<CryptoCurrency> GetCurrencyFromRemoteServer()
		{
			var jsonData = _client.DownloadString(Request);

			return _deserializer.DeserializeJsonData(jsonData);
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
