using System.ComponentModel.DataAnnotations;

namespace Mindmath.Domain.Models
{
	public class Deposit
	{
		[Key]
		public Guid Id { get; set; }
		public double Amount { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public Guid? WalletId { get; set; }
		public Wallet Wallet { get; set; }
	}
}
