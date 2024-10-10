using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.InputParameters.DTO
{
	public record InputParameterForUpdateDto
	{
		[Required]
		public bool Active { get; init; }
	}
}
