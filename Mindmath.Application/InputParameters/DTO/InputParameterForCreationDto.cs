using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.InputParameters.DTO
{
	public record InputParameterForCreationDto
	{
		[Required]
		public string Input { get; init; }
	}
}
