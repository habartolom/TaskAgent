namespace TaskLog.DTO
{
	public class DTTaskTimeSlipClient
	{
		public Guid TimeSlipId { get; set; }
		public Guid ClientId { get; set; }
		public Guid DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public Guid TaskId { get; set; }
		public string TaskDescription { get; set; }
		public DateTime ExecutionDate { get; set; }
		public string ExecutionTruncateDate { get; set; }
		public string Duration { get; set; }
		public string Comment { get; set; }
	}
}
