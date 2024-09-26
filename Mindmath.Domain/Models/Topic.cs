using System.ComponentModel.DataAnnotations;

namespace Mindmath.Domain.Models
{
	public class Topic
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateOnly CreatedAt { get; set; }
		public DateOnly UpdatedAt { get; set; }
		public bool Active { get; set; }
		public Guid? ChapterId { get; set; }
		public Chapter Chapter { get; set; }
		public ICollection<ProblemType> ProblemTypes { get; set; } = new List<ProblemType>();
	}
}
