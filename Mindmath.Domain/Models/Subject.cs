using System.ComponentModel.DataAnnotations;

namespace Mindmath.Domain.Models
{
	public class Subject
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateOnly CreatedAt { get; set; }
		public DateOnly UpdatedAt { get; set; }
		public bool Status { get; set; }
		public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
	}
}
