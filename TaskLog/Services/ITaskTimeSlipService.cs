using TaskLog.Database.Entities;
using TaskLog.DTO;

namespace TaskLog.Services
{
	public interface ITaskTimeSlipService
	{
		Task<TaskTimeSlip> CreateAsync(DTTaskTimeSlip entity);
		Task DeleteAsync(Guid id);
		Task<TaskTimeSlip> FindByIdAsync(Guid id);
		IEnumerable<TaskTimeSlip> GetAll();
		Task<TaskTimeSlip> UpdateAsync(DTTaskTimeSlip entity, Guid id);
	}
}
