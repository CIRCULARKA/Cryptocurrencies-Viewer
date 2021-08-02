using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using CurrencyViewer.Models;
using CurrencyViewer.CoinMarketApi;

namespace CurrencyViewer
{
	public class Startup
	{
		private string _apiEndpointRoute =
			"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddDbContext<UsersDbContext>();
			services.AddSingleton<DbContextBase, DefaultDbContext>();
			services.AddIdentity<User, IdentityRole>(
				options =>
				{
					options.Password.RequiredLength = 0;
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;

				}
			).AddEntityFrameworkStores<UsersDbContext>();

			services.AddScoped<IApiProvider, ApiProvider>(
				s => new ApiProvider(
					new StreamReader(
						new FileStream(
							Directory.
								GetCurrentDirectory() +
								"\\api.txt",
							FileMode.OpenOrCreate
						)
					)
				)
			);
			services.AddScoped<ICurrencyDeserializer<CryptoCurrency>, CryptoCurrencyDeserializer>();
			services.AddScoped<ICurrencyProvider<CryptoCurrency>, CryptoCurrencyProvider>(
				s => new CryptoCurrencyProvider(
					_apiEndpointRoute,
					new Dictionary<string, string> { },
					s.GetService<ICurrencyDeserializer<CryptoCurrency>>(),
					s.GetService<IApiProvider>()
				)
			);
			services.AddScoped<IRepository, DefaultRepository>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(
				endpoints =>
					endpoints.MapControllerRoute(
						name: "default",
						pattern: "{controller=Home}/{action=GetCryptocurrenciesList}"
					)
			);
		}
	}
}
