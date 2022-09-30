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
	public class CustomTaskController : ControllerBase
	{
		private readonly ICustomTaskService _customTaskService;

		public CustomTaskController(ICustomTaskService customTaskService)
		{
			_customTaskService = customTaskService;
		}

		[HttpPost]
		public async Task<IActionResult> Insert([FromBody] DTCustomTask dtCustomTask)
		{
			try
			{
				CustomTask client =  await _customTaskService.CreateAsync(dtCustomTask);
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
				_customTaskService.DeleteAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetById(Guid id)
		{
			try
			{
				var task = _customTaskService.FindByIdAsync(id);
				return Ok(task);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var tasks = _customTaskService.GetAll();
				return Ok(tasks);
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.InternalServerError.ToString(), ex.ToString());
			}
		}

		[HttpGet]
		[Route("department")]
		public IActionResult GetAllIncludeDepartment()
		{
			try
			{
				var tasks = _customTaskService.GetAllIncludeDepartment().OrderBy(x => x.DepartmentName).ThenBy(x => x.Description);
				return Ok(tasks);
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.InternalServerError.ToString(), ex.ToString());
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClient([FromBody] DTCustomTask dtCustomTask, Guid id)
		{
			try
			{
				var task = await _customTaskService.UpdateAsync(dtCustomTask, id);
				return Ok(task);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

	}
}
