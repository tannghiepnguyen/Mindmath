namespace Mindmath.Service.Solutions.DTO
{
	public record SolutionReturnDto
	{
		public Guid Id { get; init; }
		public string Link { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
	}
}
