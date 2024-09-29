namespace Mindmath.Application.Topics.DTO
{
	public record TopicReturnDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }
	}
}
