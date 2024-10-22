using Microsoft.AspNetCore.Identity;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Users.DTO;


namespace Mindmath.Service.Users
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthentication);
		Task<TokenDto> CreateToken(bool populateExp);
		Task<TokenDto> RefreshToken(TokenDto tokenDto);
		Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto);
		Task<IdentityResult> DeleteUser(string userId);
		Task<UserReturnDto> GetUserById(string userId);
		Task<(IEnumerable<UserReturnDto> users, MetaData MetaData)> GetUsers(UserParameters userParameters);
		Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
	}
}
