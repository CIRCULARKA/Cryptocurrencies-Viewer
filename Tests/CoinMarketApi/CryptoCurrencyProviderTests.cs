using Moq;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CryptocurrenciesViewer.CoinMarketApi;
using CryptocurrenciesViewer.Models;

namespace CryptocurrenciesViewer.Tests
{
	public class CryptoCurrencyProviderTests
	{
		[Fact]
		public void IsRequestBuildedRight()
		{
			// Arrange & Act
			var apiProviderMock = new Mock<IApiProvider>();
			apiProviderMock.
				Setup(provider => provider.GetApiKey()).
					Returns("api key in this test is unnecessary");

			var provider = new CryptoCurrencyProvider(
				"endpoint",
				new Dictionary<string, string> {
					{ "limit", "2300" },
					{ "start", "53" },
					{ "sort", "cmc_rank" }
				},
				null,
				apiProviderMock.Object
			);

			// Assert
			Assert.Equal("http://endpoint/?limit=2300&start=53&sort=cmc_rank", provider.Request);
		}

		[Fact]
		public void IsReturnedCurrencyCorrect()
		{
			// Arrange
			var apiProviderMock = new Mock<IApiProvider>();
			apiProviderMock.
				Setup(p => p.GetApiKey()).
					// This is sandbox api key from https://pro.coinmarketcap.com/api/v1#section/Quick-Start-Guide
					Returns("b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c");

			var deserializer = new CryptoCurrencyDeserializer();

			var provider = new CryptoCurrencyProvider(
				"sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest",
				new Dictionary<string, string> {
					{ "limit", "1" }
				},
				deserializer,
				apiProviderMock.Object
			);

			// Act
			IEnumerable<CryptoCurrency> result =
				provider.GetCurrencyFromRemoteServer();

			// Assert
			Assert.True(result.Count() > 0);
		}
	}
}
