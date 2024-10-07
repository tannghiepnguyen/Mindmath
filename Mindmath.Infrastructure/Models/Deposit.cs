using System.ComponentModel.DataAnnotations;

namespace Mindmath.Repository.Models
{
	public class Deposit
	{
		[Key]
		public Guid Id { get; set; }
		public double Amount { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public string? UserId { get; set; }
		public User User { get; set; }
	}
}
