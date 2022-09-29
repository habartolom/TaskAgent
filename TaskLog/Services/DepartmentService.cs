using Newtonsoft.Json;
using TaskLog.Database.Entities;
using TaskLog.DTO;
using TaskLog.Repositories;

namespace TaskLog.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;
		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}
		public async Task<Department> CreateAsync(DTDepartment dtDepartment)
		{
			var json = JsonConvert.SerializeObject(dtDepartment);
			Department entity = JsonConvert.DeserializeObject<Department>(json);
			entity.Id = Guid.NewGuid();
			return await _departmentRepository.CreateAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			Department entity = await FindByIdAsync(id);
			await _departmentRepository.DeleteAsync(entity);
		}

		public async Task<Department> FindByIdAsync(Guid id)
		{
			return await _departmentRepository.FindByIdAsync(id);
		}

		public IEnumerable<Department> GetAll()
		{
			return _departmentRepository.GetAll().AsEnumerable();
		}

		public async Task<Department> UpdateAsync(DTDepartment dtDepartment, Guid id)
		{
			var json = JsonConvert.SerializeObject(dtDepartment);
			Department entity = JsonConvert.DeserializeObject<Department>(json);
			entity.Id = id;
			return await _departmentRepository.UpdateAsync(entity);
		}
	}
}
