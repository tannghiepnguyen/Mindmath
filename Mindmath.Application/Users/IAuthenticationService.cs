using Microsoft.AspNetCore.Identity;
using Mindmath.Application.Users.DTO;

namespace Mindmath.Application.Users
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthentication);
		Task<string> CreateToken();
	}
}
