using Login.Database.Entities;
using Login.DTO;
using Login.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Login.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientController : ControllerBase
	{
		private readonly IClientService _clientService;
		public ClientController(IClientService clientService)
		{
			_clientService = clientService;
		}

		[HttpGet]
		public IActionResult getAllClientes()
		{
			try
			{
				var clients = _clientService.GetAll().ToList();
				return Ok(clients);
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.InternalServerError.ToString(), ex.ToString());
			}
		}

		[HttpGet("{Email}/{Password}")]
		public IActionResult getClienteByEmailAndPassword(string Email, string Password)
		{
			try
			{
				var client = _clientService.GetByEmailAndPassword(Email, Password);
				return Ok(client);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpGet("{Email}")]
		public IActionResult getClienteByEmail(string Email)
		{
			try
			{
				var client = _clientService.GetByEmail(Email);
				return Ok(client);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPost]
		public async Task<IActionResult> InsertClient([FromBody] DTClient client)
		{
			try
			{
				await _clientService.Insert(client);
				return Created("Cliente Creado", true);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClient([FromBody] DTClient client, string id)
		{
			try
			{
				await _clientService.Update(client, id);
				return Created("Cliente Actualizado", true);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteClient(string id)
		{
			try
			{
				_clientService.Delete(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
