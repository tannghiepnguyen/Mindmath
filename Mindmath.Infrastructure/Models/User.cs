
using Microsoft.AspNetCore.Identity;

namespace Mindmath.Repository.Models
{
	public class User : IdentityUser
	{
		public string Fullname { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
		public bool Active { get; set; }
		public string? Avatar { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		public Wallet Wallet { get; set; }
		public ICollection<InputParameter> InputParameters { get; set; }
		public ICollection<Transaction> Transactions { get; set; }
	}
}
