using Xunit;
using System.IO;
using CurrencyViewer.CoinMarketApi;

namespace CurrencyViewer.Tests
{
	public class ApiProviderTests
	{
		[Fact]
		public void IsApiLoadsProperly()
		{
			// Assert
			var apiProvider = new ApiProvider(
				new StreamReader(TestsDirectoryPath + "api_test.txt")
			);

			// Act
			var result = apiProvider.GetApiKey();

			// Assert
			Assert.Equal("thats api", result);
		}

		private string TestsDirectoryPath =>
			Directory.GetParent(Directory.GetCurrentDirectory()).
				Parent.Parent.FullName + "\\";
	}
}
