namespace Mindmath.Service.Subjects.DTO
{
	public record SubjectForUpdateDto
	{
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
