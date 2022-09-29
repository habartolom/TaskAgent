using System.ComponentModel.DataAnnotations;

namespace Login.DTO
{
	public class DTClient
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string UserName { get; set; }
	}
}
