using Microsoft.AspNetCore.Identity;

namespace Mindmath.Domain.Models
{
	public class User : IdentityUser
	{
		public string Fullname { get; set; }
		public string Gender { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public DateOnly CreateAt { get; set; }
		public DateOnly UpdateAt { get; set; }
		public string? Avatar { get; set; }
		public bool Active { get; set; }
		public Wallet Wallet { get; set; }
		public ICollection<InputParameter> InputParameters { get; set; }
	}
}
