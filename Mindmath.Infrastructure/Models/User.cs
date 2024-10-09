
using Microsoft.AspNetCore.Identity;

namespace Mindmath.Repository.Models
{
	public class User : IdentityUser
	{
		public string Fullname { get; set; }
		public string Gender { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }
		public string? Avatar { get; set; }
		public bool Active { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		public Wallet Wallet { get; set; }
		public ICollection<InputParameter> InputParameters { get; set; }
		public ICollection<Transaction> Transactions { get; set; }
		public ICollection<Deposit> Deposits { get; set; }
	}
}
