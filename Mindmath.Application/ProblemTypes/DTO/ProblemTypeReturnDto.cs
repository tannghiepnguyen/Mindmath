namespace Mindmath.Application.ProblemTypes.DTO
{
	public record ProblemTypeReturnDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
