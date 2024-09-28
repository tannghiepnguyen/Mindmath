using System.ComponentModel.DataAnnotations;

namespace Mindmath.Domain.Models
{
	public class Solution
	{
		[Key]
		public Guid Id { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
		public DateOnly CreatedAt { get; set; }
		public DateOnly UpdatedAt { get; set; }
		public bool Active { get; set; }
		public Guid? InputParameterId { get; set; }
		public InputParameter InputParameter { get; set; }
		public string? UserId { get; set; }
		public User User { get; set; }
		public Guid? TransactionId { get; set; }
		public Transaction Transaction { get; set; }

	}
}
