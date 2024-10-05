using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Users.DTO
{
	public record UserForAuthenticationDTO
	{
		[Required(ErrorMessage = "Username is required")]
		public string UserName { get; init; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; init; }
	}
}
