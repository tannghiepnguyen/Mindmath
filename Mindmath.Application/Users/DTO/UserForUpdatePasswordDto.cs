using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Users.DTO
{
	public record UserForUpdatePasswordDto
	{
		[Required]
		public string OldPassword { get; init; }
		[Required]
		public string NewPassword { get; init; }
	}
}
