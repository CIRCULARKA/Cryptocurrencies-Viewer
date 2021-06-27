using Microsoft.EntityFrameworkCore;

namespace CryptocurrenciesViewer.Models
{
	public class DefaultDbContext : DbContextBase
	{
		public DefaultDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
			builder.UseSqlServer("Server=(local);Database=CryptoCurrenciesDB;Trusted_Connection=True");

	}
}
