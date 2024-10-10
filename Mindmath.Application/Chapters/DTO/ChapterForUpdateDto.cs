using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Chapters.DTO
{
	public record ChapterForUpdateDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
		[Required]
		public bool Active { get; init; }
	}
}
