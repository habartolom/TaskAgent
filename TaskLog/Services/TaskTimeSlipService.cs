using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaskLog.Database.Entities;
using TaskLog.DTO;
using TaskLog.Repositories;

namespace TaskLog.Services
{
	public class TaskTimeSlipService : ITaskTimeSlipService
	{
		private readonly ITaskTimeSlipRepository _taskTimeSlipRepository;
		private readonly ICustomTaskRepository _customTaskRepository;
		private readonly IDepartmentRepository _departmentRepository;
		public TaskTimeSlipService(ITaskTimeSlipRepository taskTimeSlipRepository, ICustomTaskRepository customTaskRepository, IDepartmentRepository departmentRepository)
		{
			_taskTimeSlipRepository = taskTimeSlipRepository;
			_customTaskRepository = customTaskRepository;
			_departmentRepository = departmentRepository;
		}
		public async Task<TaskTimeSlip> CreateAsync(DTTaskTimeSlip dtTaskTimeSlip)
		{
			var json = JsonConvert.SerializeObject(dtTaskTimeSlip);
			TaskTimeSlip entity = JsonConvert.DeserializeObject<TaskTimeSlip>(json);
			entity.Id = Guid.NewGuid();
			return await _taskTimeSlipRepository.CreateAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			TaskTimeSlip entity = await FindByIdAsync(id);
			await _taskTimeSlipRepository.DeleteAsync(entity);
		}

		public async Task<TaskTimeSlip> FindByIdAsync(Guid id)
		{
			return await _taskTimeSlipRepository.FindByIdAsync(id);
		}

		public IEnumerable<TaskTimeSlip> GetAll()
		{
			return _taskTimeSlipRepository.GetAll().AsEnumerable();
		}

		public IEnumerable<DTTaskTimeSlipClient> GetByClient(Guid clientId)
		{
			var tasktimeSlips = _taskTimeSlipRepository.GetByClientId(clientId).AsEnumerable();
			var tasks = _customTaskRepository.GetAll().AsEnumerable();
			var departments = _departmentRepository.GetAll().AsEnumerable();

			var data = 
				from timeslip in tasktimeSlips
				join task in tasks on timeslip.TaskId equals task.Id
				join department in departments on task.DepartmentId equals department.Id
				select new DTTaskTimeSlipClient
				{
					TimeSlipId = timeslip.Id,
					ClientId = clientId,
					DepartmentId = department.Id,
					DepartmentName = department.Name,
					TaskId = task.Id,
					TaskDescription = task.Description,
					ExecutionDate = timeslip.ExecutionDate,
					ExecutionTruncateDate = timeslip.ExecutionDate.ToString("yyyy-MM-dd"),
					Duration = timeslip.Duration,
					Comment = timeslip.Comment
				};

			return data.OrderBy(x => x.ExecutionDate).AsEnumerable();
		}

		public async Task<TaskTimeSlip> UpdateAsync(DTTaskTimeSlip dtTaskTimeSlip, Guid id)
		{
			var json = JsonConvert.SerializeObject(dtTaskTimeSlip);
			TaskTimeSlip entity = JsonConvert.DeserializeObject<TaskTimeSlip>(json);
			entity.Id = id;
			return await _taskTimeSlipRepository.UpdateAsync(entity);
		}
	}
}
