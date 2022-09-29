using Microsoft.EntityFrameworkCore;
using TaskLog.Database.Context;
using TaskLog.Database.Entities;

namespace TaskLog.Repositories
{
	public class CustomTaskRepository : BaseCRUDRepository<CustomTask>, ICustomTaskRepository
	{
		public CustomTaskRepository(SqLiteDbContext dbContext) : base(dbContext)
		{

		}
	}
}
