using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CurrencyViewer.Models;
using CurrencyViewer.Models.Factories;

namespace CurrencyViewer
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddSingleton<IRepository, DefaultRepository>(
				services => new RepositoryFactory().
					CreateDefaultRepository()
			);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseRouting();
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
