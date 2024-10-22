using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.ProblemTypes.DTO
{
	public record ProblemTypeForUpdateDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
		[Required]
		public int NumberOfInputs { get; init; }
	}
}
