using TaskLog.Database.Context;
using TaskLog.Database.Entities;

namespace TaskLog.Repositories
{
	public class TaskTimeSlipRepository : BaseCRUDRepository<TaskTimeSlip>, ITaskTimeSlipRepository
	{
		public TaskTimeSlipRepository(SqLiteDbContext dbContext) : base(dbContext)
		{

		}
	}
}
