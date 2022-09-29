using TaskLog.Database.Entities;
using TaskLog.DTO;

namespace TaskLog.Services
{
	public interface ICustomTaskService
	{
		Task<CustomTask> CreateAsync(DTCustomTask entity);
		Task DeleteAsync(Guid id);
		Task<CustomTask> FindByIdAsync(Guid id);
		IEnumerable<CustomTask> GetAll();
		Task<CustomTask> UpdateAsync(DTCustomTask entity, Guid id);
	}
}
