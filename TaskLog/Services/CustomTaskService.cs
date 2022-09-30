using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TaskLog.Database.Entities;
using TaskLog.DTO;
using TaskLog.Repositories;

namespace TaskLog.Services
{
	public class CustomTaskService : ICustomTaskService
	{
		private readonly ICustomTaskRepository _customTaskRepository;
		private readonly IDepartmentRepository _departmentRepository;
		public CustomTaskService(ICustomTaskRepository customTaskRepository, IDepartmentRepository departmentRepository)
		{
			_customTaskRepository = customTaskRepository;
			_departmentRepository = departmentRepository;
		}
		public async Task<CustomTask> CreateAsync(DTCustomTask dtCustomTask)
		{
			var json = JsonConvert.SerializeObject(dtCustomTask);
			CustomTask entity = JsonConvert.DeserializeObject<CustomTask>(json);
			entity.Id = Guid.NewGuid();
			return await _customTaskRepository.CreateAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			CustomTask entity = await FindByIdAsync(id);
			await _customTaskRepository.DeleteAsync(entity);
		}

		public async Task<CustomTask> FindByIdAsync(Guid id)
		{
			return await _customTaskRepository.FindByIdAsync(id);
		}

		public IEnumerable<CustomTask> GetAll()
		{
			return _customTaskRepository.GetAll().AsEnumerable();
		}

		public IEnumerable<DTTaskDepartment> GetAllIncludeDepartment()
		{
			var tasks = _customTaskRepository.GetAll().AsEnumerable();
			var departments = _departmentRepository.GetAll().AsEnumerable();

			var data = 
				from task in tasks
				join department in departments on task.DepartmentId equals department.Id
				select new DTTaskDepartment
				{
					Id = task.Id,
					Description = task.Description,
					DepartmentId = task.DepartmentId,
					DepartmentName = department.Name
				};

			return data.AsEnumerable();
		}

		public async Task<CustomTask> UpdateAsync(DTCustomTask dtCustomTask, Guid id)
		{
			var json = JsonConvert.SerializeObject(dtCustomTask);
			CustomTask entity = JsonConvert.DeserializeObject<CustomTask>(json);
			entity.Id = id;
			return await _customTaskRepository.UpdateAsync(entity);
		}
	}
}
