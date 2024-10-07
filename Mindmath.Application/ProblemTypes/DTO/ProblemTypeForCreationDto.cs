namespace Mindmath.Service.ProblemTypes.DTO
{
	public record ProblemTypeForCreationDto
	{
		public string Name { get; init; }
		public string Description { get; init; }
		public int NumberOfInputs { get; init; }
	}
}
