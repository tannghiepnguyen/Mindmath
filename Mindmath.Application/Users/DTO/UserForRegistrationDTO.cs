namespace Mindmath.Application.Users.DTO
{
	public class UserForRegistrationDTO
	{
		public string Fullname { get; init; }
		public string Gender { get; init; }
		public DateOnly DateOfBirth { get; init; }
		public string Email { get; init; }
		public string Password { get; init; }
		public string PhoneNumber { get; init; }
		public string UserName { get; init; }
	}
}
