using System.ComponentModel.DataAnnotations;

namespace TaskLog.Database.Entities
{
	public class CustomTask
	{
		[Key]
		public Guid Id { get; set; }
		
		[Required]
		public Guid DepartmentId { get; set; }
		
		[Required]
		public string Description { get; set; }

		public virtual Department Department { get; set; }

		public virtual ICollection<TaskTimeSlip> TaskTimeSlips { get; set; }
	}
}
