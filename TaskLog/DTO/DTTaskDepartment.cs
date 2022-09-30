using System.ComponentModel.DataAnnotations;
using TaskLog.Database.Entities;

namespace TaskLog.DTO
{
	public class DTTaskDepartment
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public Guid DepartmentId { get; set; }
		public string DepartmentName { get; set; }
	}
}
