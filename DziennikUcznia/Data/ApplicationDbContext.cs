using DziennikUcznia.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
	}
}
