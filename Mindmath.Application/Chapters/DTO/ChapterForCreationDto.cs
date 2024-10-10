using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Chapters.DTO
{
	public record ChapterForCreationDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
	}
}
