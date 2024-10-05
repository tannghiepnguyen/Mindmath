using System.ComponentModel.DataAnnotations;

namespace Mindmath.Repository.Models
{
	public class Chapter
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Active { get; set; }
		public Guid SubjectId { get; set; }
		public Subject Subject { get; set; }
		public ICollection<Topic> Topics { get; set; } = new List<Topic>();
	}
}
