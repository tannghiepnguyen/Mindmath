using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Users.DTO
{
	public record UserForRegistrationDTO
	{
		[Required]
		public string Fullname { get; init; }
		[Required]
		public string Gender { get; init; }
		[Required]
		public string Email { get; init; }
		[Required]
		public string Password { get; init; }
		[Required]
		public string PhoneNumber { get; init; }
		[Required]
		public string UserName { get; init; }
	}
}
