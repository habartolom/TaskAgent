using Login.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Login.Database.Context
{
	public class SqLiteDbContext : DbContext
	{
		public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options) : base(options){}

		public DbSet<Client> Clients { get; set; }
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Client>().HasIndex(u => u.Email).IsUnique();
		}
	}
}
