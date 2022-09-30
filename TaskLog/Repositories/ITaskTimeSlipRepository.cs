using TaskLog.Database.Entities;

namespace TaskLog.Repositories
{
	public interface ITaskTimeSlipRepository : IBaseCRUDRepository<TaskTimeSlip>
	{
		IQueryable<TaskTimeSlip> GetByClientId(Guid id);
	}
}
