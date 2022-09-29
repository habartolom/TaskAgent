using System.ComponentModel.DataAnnotations;

namespace TaskLog.DTO
{
	public class DTCustomTask
	{
		[Required]
		public Guid DepartmentId { get; set; }

		[Required]
		public string Description { get; set; }
	}
}
