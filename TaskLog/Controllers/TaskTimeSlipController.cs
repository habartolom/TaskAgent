using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskLog.Database.Entities;
using TaskLog.DTO;
using TaskLog.Services;

namespace TaskLog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskTimeSlipController : ControllerBase
	{
		private readonly ITaskTimeSlipService _taskTimeSlipService;

		public TaskTimeSlipController(ITaskTimeSlipService taskTimeSlipService)
		{
			_taskTimeSlipService = taskTimeSlipService;
		}

		[HttpPost]
		public async Task<IActionResult> Insert([FromBody] DTTaskTimeSlip dtTaskTimeSlip)
		{
			try
			{
				TaskTimeSlip client = await _taskTimeSlipService.CreateAsync(dtTaskTimeSlip);
				return Ok(client);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			try
			{
				_taskTimeSlipService.DeleteAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet("{id}")]
		public IActionResult getById(Guid id)
		{
			try
			{
				var TaskTimeSlip = _taskTimeSlipService.FindByIdAsync(id);
				return Ok(TaskTimeSlip);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet]
		public IActionResult getAll()
		{
			try
			{
				var TaskTimeSlips = _taskTimeSlipService.GetAll();
				return Ok(TaskTimeSlips);
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.InternalServerError.ToString(), ex.ToString());
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClient([FromBody] DTTaskTimeSlip dtTaskTimeSlip, Guid id)
		{
			try
			{
				var TaskTimeSlip = await _taskTimeSlipService.UpdateAsync(dtTaskTimeSlip, id);
				return Ok(TaskTimeSlip);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
