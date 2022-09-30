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
		IEnumerable<DTTaskDepartment> GetAllIncludeDepartment();
		Task<CustomTask> UpdateAsync(DTCustomTask entity, Guid id);
	}
}
