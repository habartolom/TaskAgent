using System.ComponentModel.DataAnnotations;

namespace TaskLog.Database.Entities
{
	public class CustomTask
	{
		[Key]
		public string Id { get; set; }
		
		[Required]
		public string ClientId { get; set; }
		
		public string Comment { get; set; }
		
		[Required]
		public string DepartmentId { get; set; }
		
		[Required]
		public string Description { get; set; }
		
		[Required]
		public string Duration { get; set; }

		public virtual Department Department { get; set; }
	}
}
