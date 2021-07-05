using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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

			services.AddDbContext<UsersDbContext>();
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

			services.AddSingleton<IRepository, DefaultRepository>(
				services => new RepositoryFactory().
					CreateDefaultRepository()
			);
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
