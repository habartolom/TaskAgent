using System.ComponentModel.DataAnnotations;

namespace TaskLog.Database.Entities
{
	public class Department
	{
		[Key]
		public string Id { get; set; }


		[Required]
		public string Name { get; set; }

		public virtual ICollection<CustomTask> CustomTasks { get; set; }
	}
}
