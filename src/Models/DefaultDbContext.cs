using Microsoft.EntityFrameworkCore;

namespace CryptocurrenciesViewer.Models
{
	public class DefaultDbContext : DbContext
	{
		public DbSet<CryptoCurrency> Currencies { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
			builder.UseSqlServer("Server=(local);Database=CryptoCurrenciesDB;Trusted_Connection=True");

		protected override void OnModelCreating(ModelBuilder bulider)
		{
			bulider.Entity<CryptoCurrency>().HasKey(cc => cc.ID);
		}
	}
}
