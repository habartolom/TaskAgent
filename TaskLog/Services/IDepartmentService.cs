using TaskLog.Database.Entities;
using TaskLog.DTO;

namespace TaskLog.Services
{
	public interface IDepartmentService
	{
		Task<Department> CreateAsync(DTDepartment entity);
		Task DeleteAsync(Guid id);
		Task<Department> FindByIdAsync(Guid id);
		IEnumerable<Department> GetAll();
		Task<Department> UpdateAsync(DTDepartment entity, Guid id);
	}
}
