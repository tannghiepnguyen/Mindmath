using System.ComponentModel.DataAnnotations;

namespace Mindmath.Domain.Models
{
	public class Chapter
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int NumberOfTopic { get; set; }
		public DateOnly CreatedAt { get; set; }
		public DateOnly UpdatedAt { get; set; }
		public bool Status { get; set; }
		public Guid SubjectId { get; set; }
		public Subject Subject { get; set; }
		public ICollection<Topic> Topics { get; set; } = new List<Topic>();
	}
}
