namespace Mindmath.Service.Chapters.DTO
{
	public record ChapterForUpdateDto
	{
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
