namespace Mindmath.Service.Subjects.DTO
{
	public record SubjectReturnDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
