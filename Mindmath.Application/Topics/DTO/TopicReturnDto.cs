namespace Mindmath.Service.Topics.DTO
{
	public record TopicReturnDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
