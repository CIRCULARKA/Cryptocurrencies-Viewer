using Moq;
using Xunit;
using System.Collections.Generic;
using CryptocurrenciesViewer.CoinMarketApi;

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
	}
}
