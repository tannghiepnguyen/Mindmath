using Microsoft.AspNetCore.Identity;
using Mindmath.Service.Users.DTO;


namespace Mindmath.Service.Users
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthentication);
		Task<string> CreateToken();
		Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto);
		Task<UserReturnDto> GetUserById(string userId);
		Task<IEnumerable<UserReturnDto>> GetUsers();
		Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
	}
}
