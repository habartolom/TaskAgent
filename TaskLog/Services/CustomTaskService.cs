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
		public CustomTaskService(ICustomTaskRepository customTaskRepository)
		{
			_customTaskRepository = customTaskRepository;
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

		public async Task<CustomTask> UpdateAsync(DTCustomTask dtCustomTask, Guid id)
		{
			var json = JsonConvert.SerializeObject(dtCustomTask);
			CustomTask entity = JsonConvert.DeserializeObject<CustomTask>(json);
			entity.Id = id;
			return await _customTaskRepository.UpdateAsync(entity);
		}
	}
}
