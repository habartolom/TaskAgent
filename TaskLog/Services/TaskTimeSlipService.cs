using Newtonsoft.Json;
using TaskLog.Database.Entities;
using TaskLog.DTO;
using TaskLog.Repositories;

namespace TaskLog.Services
{
	public class TaskTimeSlipService : ITaskTimeSlipService
	{
		private readonly ITaskTimeSlipRepository _taskTimeSlipRepository;
		public TaskTimeSlipService(ITaskTimeSlipRepository taskTimeSlipRepository)
		{
			_taskTimeSlipRepository = taskTimeSlipRepository;
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

		public async Task<TaskTimeSlip> UpdateAsync(DTTaskTimeSlip dtTaskTimeSlip, Guid id)
		{
			var json = JsonConvert.SerializeObject(dtTaskTimeSlip);
			TaskTimeSlip entity = JsonConvert.DeserializeObject<TaskTimeSlip>(json);
			entity.Id = id;
			return await _taskTimeSlipRepository.UpdateAsync(entity);
		}
	}
}
