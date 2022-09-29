using System.ComponentModel.DataAnnotations;

namespace TaskLog.DTO
{
	public class DTDepartment
	{
		[Required]
		public string Name { get; set; }
	}
}
