using System.ComponentModel.DataAnnotations;

namespace TaskLog.Database.Entities
{
	public class TaskTimeSlip
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public Guid TaskId { get; set; }

		[Required]
		public Guid ClientId { get; set; }

		[Required]
		public DateTime ExecutionDate { get; set; }

		[Required]
		public string Duration { get; set; }

		public string Comment { get; set; }

		public virtual CustomTask Task { get; set; }
	}
}
