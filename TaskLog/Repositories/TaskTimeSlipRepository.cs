using Microsoft.EntityFrameworkCore;
using TaskLog.Database.Context;
using TaskLog.Database.Entities;

namespace TaskLog.Repositories
{
	public class TaskTimeSlipRepository : BaseCRUDRepository<TaskTimeSlip>, ITaskTimeSlipRepository
	{
		private readonly SqLiteDbContext _dbContext;
		public TaskTimeSlipRepository(SqLiteDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<TaskTimeSlip> GetByClientId(Guid clientId)
		{
			return _dbContext.TaskTimeSlips.Where(x => x.ClientId == clientId);
		}
	}
}
