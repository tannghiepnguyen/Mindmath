using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Mindmath.Service.Users.DTO
{
	public record UserForUpdateDto
	{
		[Required]
		public string Fullname { get; init; }
		[Required]
		public string Email { get; init; }
		[Required]
		public string PhoneNumber { get; init; }
		public IFormFile File { get; init; }
	}
}
