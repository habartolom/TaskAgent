using Microsoft.EntityFrameworkCore;
using TaskLog.Database.Entities;

namespace TaskLog.Database.Context
{
	public class SqLiteDbContext : DbContext
	{
		public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options) : base(options){}

		public DbSet<CustomTask> Tasks { get; set; }
		public DbSet<Department> Departments { get; set; }
	}
}
