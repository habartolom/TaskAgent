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
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpPost]
		public async Task<IActionResult> Insert([FromBody] DTDepartment dtDepartment)
		{
			try
			{
				Department client = await _departmentService.CreateAsync(dtDepartment);
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
				_departmentService.DeleteAsync(id);
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
				var department = _departmentService.FindByIdAsync(id);
				return Ok(department);
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
				var departments = _departmentService.GetAll();
				return Ok(departments);
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.InternalServerError.ToString(), ex.ToString());
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClient([FromBody] DTDepartment dtDepartment, Guid id)
		{
			try
			{
				var department = await _departmentService.UpdateAsync(dtDepartment, id);
				return Ok(department);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
