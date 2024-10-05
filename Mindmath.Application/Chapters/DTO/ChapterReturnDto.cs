namespace Mindmath.Service.Chapters.DTO
{
	public record ChapterReturnDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
