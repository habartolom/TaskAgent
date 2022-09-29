using Microsoft.EntityFrameworkCore;
using TaskLog.Database.Context;
using TaskLog.Database.Entities;

namespace TaskLog.Repositories
{
	public class DepartmentRepository : BaseCRUDRepository<Department>, IDepartmentRepository
	{
		public DepartmentRepository(SqLiteDbContext dbContext) : base(dbContext)
		{
		}
	}
}
