using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Subjects.DTO
{
	public record SubjectForUpdateDto
	{
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
		[Required]
		public bool Active { get; init; }
	}
}
