namespace Mindmath.Application.Topics.DTO
{
	public record TopicForUpdateDto
	{
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
