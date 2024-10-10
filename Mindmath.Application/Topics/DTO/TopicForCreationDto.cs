using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Topics.DTO
{
	public record TopicForCreationDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
	}
}
