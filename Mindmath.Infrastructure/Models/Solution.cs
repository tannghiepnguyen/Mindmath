using System.ComponentModel.DataAnnotations;

namespace Mindmath.Repository.Models
{
	public class Solution
	{
		[Key]
		public Guid Id { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Active { get; set; }
		public Guid? InputParameterId { get; set; }
		public InputParameter InputParameter { get; set; }
		public Guid? TransactionId { get; set; }
		public Transaction Transaction { get; set; }

	}
}
