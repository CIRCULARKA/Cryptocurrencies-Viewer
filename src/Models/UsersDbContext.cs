using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CurrencyViewer.Models
{
	public class UsersDbContext : IdentityDbContext<User>
	{
		public UsersDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CryptoUsers;Trusted_Connection=True");
		}
	}
}
