using Xunit;
using System.Linq;
using System.Collections.Generic;
using CryptocurrenciesViewer.Models;
using CryptocurrenciesViewer.CoinMarketApi;

public class DataDeserializerTests
{
	[Fact]
	public void IsDeserializedProperly()
	{
		// Arrange
		var deserializer = new DataDeserializer();

		var input = "{\"data\":[{\"id\":1,\"name\":\"Bitcoin\",\"symbol\":\"BTC\",\"quote\"" +
			":{\"USD\":{\"price\":31500.808533861516,\"percent_change_1h\":0.85104479,\"percent_change_24h\":-0.9601547," +
			"\"market_cap\":590424568476.2977}}}]}";

		// Act
		IEnumerable<CryptoCurrency> result = deserializer.DeserializeJsonData(input);

		// Arrange
		Assert.True(result.Count() == 1);

		foreach (var currency in result)
		{
			Assert.Equal("Bitcoin", currency.Name);
			Assert.Equal("BTC", currency.Symbol);
			Assert.Equal(31500.808534M, currency.Price, 6);
			Assert.Equal(0.85104479M, currency.Last1HourDynamics, 8);
			Assert.Equal(-0.9601547M, currency.Last24HoursDynamics, 7);
			Assert.Equal(590424568476.298M, currency.MarketCapitalization, 4);
		}
	}
}
