using Microsoft.EntityFrameworkCore;

namespace CurrencyViewer.Models
{
	public class DbContextBase : DbContext
	{
		public DbSet<CryptoCurrency> Currencies { get; set; }

		protected override void OnModelCreating(ModelBuilder bulider)
		{
			bulider.Entity<CryptoCurrency>().HasKey(cc => cc.ID);
			bulider.Entity<CryptoCurrency>().Property(cc => cc.ID).UseIdentityColumn();
		}
	}
}
