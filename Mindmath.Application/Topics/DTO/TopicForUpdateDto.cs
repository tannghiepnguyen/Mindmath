using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Topics.DTO
{
	public record TopicForUpdateDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
		[Required]
		public bool Active { get; init; }
	}
}
