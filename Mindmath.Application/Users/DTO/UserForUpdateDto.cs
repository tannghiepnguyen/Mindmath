namespace Mindmath.Service.Users.DTO
{
	public record UserForUpdateDto
	{
		public string Fullname { get; init; }
		public string Gender { get; init; }
		public DateTime DateOfBirth { get; init; }
		public string Email { get; init; }
		public string PhoneNumber { get; init; }
	}
}
