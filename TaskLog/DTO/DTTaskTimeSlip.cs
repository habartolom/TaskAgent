using System.ComponentModel.DataAnnotations;

namespace TaskLog.DTO
{
	public class DTTaskTimeSlip
	{
		[Required]
		public Guid TaskId { get; set; }

		[Required]
		public Guid ClientId { get; set; }

		[Required]
		public DateTime ExecutionDate { get; set; }

		[Required]
		public string Duration { get; set; }
		
		public string Comment { get; set; }
	}
}
