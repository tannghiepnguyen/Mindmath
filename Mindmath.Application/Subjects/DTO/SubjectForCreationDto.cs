using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Subjects.DTO
{
	public record SubjectForCreationDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
	}
}
