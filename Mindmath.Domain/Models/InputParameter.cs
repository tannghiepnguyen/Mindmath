using System.ComponentModel.DataAnnotations;

namespace Mindmath.Domain.Models
{
	public class InputParameter
	{
		[Key]
		public Guid Id { get; set; }
		public string Input { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdateAt { get; set; }
		public bool Active { get; set; }
		public Guid? ProblemTypeId { get; set; }
		public ProblemType ProblemType { get; set; }
		public string? UserId { get; set; }
		public User User { get; set; }
		public Solution Solution { get; set; }
	}
}
