using System.ComponentModel.DataAnnotations;

namespace Mindmath.Application.Users.DTO
{
	public class UserForAuthenticationDTO
	{
		[Required(ErrorMessage = "Username is required")]
		public string UserName { get; init; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; init; }
	}
}
