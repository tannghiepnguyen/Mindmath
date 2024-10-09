namespace Mindmath.Service.Users.DTO
{
	public record TokenDto
	{
		public string AccessToken { get; init; }
		public string RefreshToken { get; init; }
	}
}
