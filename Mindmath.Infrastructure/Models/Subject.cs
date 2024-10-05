using System.ComponentModel.DataAnnotations;

namespace Mindmath.Repository.Models
{
	public class Subject
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Active { get; set; }
		public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
	}
}
