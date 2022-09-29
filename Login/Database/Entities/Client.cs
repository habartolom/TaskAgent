using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Login.Database.Entities
{
	public class Client
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string UserName { get; set; }
	}
}
