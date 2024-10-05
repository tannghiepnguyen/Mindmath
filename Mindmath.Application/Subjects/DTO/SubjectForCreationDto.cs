namespace Mindmath.Service.Subjects.DTO
{
	public record SubjectForCreationDto
	{
		public string Name { get; init; }
		public string Description { get; init; }
	}
}
