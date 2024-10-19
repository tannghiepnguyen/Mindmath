using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Service.Users;
using Mindmath.Service.Users.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mindmath.Application.Users
{
	internal sealed class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IRepositoryManager repositoryManager;
		private User? user;

		public AuthenticationService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IRepositoryManager repositoryManager)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.configuration = configuration;
			this.roleManager = roleManager;
			this.repositoryManager = repositoryManager;
		}

		public async Task<TokenDto> CreateToken(bool populateExp)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims();
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

			var refreshToken = GenerateRefreshToken();

			this.user.RefreshToken = refreshToken;

			if (populateExp)
			{
				this.user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
			}

			await userManager.UpdateAsync(this.user);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return new TokenDto()
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			};
		}

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secret"])),
				ValidateLifetime = true,
				ValidIssuer = jwtSettings["validIssuer"],
				ValidAudience = jwtSettings["validAudience"]
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken;
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

			var jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}
			return principal;
		}

		private SecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenOptions = new JwtSecurityToken(
				issuer: jwtSettings.GetSection("validIssuer").Value,
				audience: jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				signingCredentials: signingCredentials,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value))
			);
			return tokenOptions;
		}

		private async Task<List<Claim>> GetClaims()
		{
			var claims = new List<Claim>
			{
				new Claim("Username", user.UserName)
			};
			var roles = await userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}
			claims.Add(new Claim("Fullname", user.Fullname));
			claims.Add(new Claim("Id", user.Id));
			claims.Add(new Claim("Email", user.Email));
			claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
			return claims;
		}

		private SigningCredentials GetSigningCredentials()
		{
			var key = Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings").GetSection("secret").Value);
			var secret = new SymmetricSecurityKey(key);
			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		public async Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.CreateAt = DateTime.Now;
			user.UpdateAt = DateTime.Now;
			user.Active = true;

			var result = await userManager.CreateAsync(user, userForRegistration.Password);
			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Roles.Teacher);
			}

			Wallet wallet = new Wallet
			{
				Id = Guid.NewGuid(),
				Balance = 0,
				UserId = user.Id
			};

			repositoryManager.Wallets.CreateWallet(wallet);
			await repositoryManager.Save();

			return result;
		}

		public async Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthentication)
		{
			user = await userManager.FindByNameAsync(userForAuthentication.UserName);

			var result = (user != null && await userManager.CheckPasswordAsync(user, userForAuthentication.Password));

			return result;
		}

		public async Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			mapper.Map(userForUpdateDto, user);

			return await userManager.UpdateAsync(user);
		}

		public async Task<UserReturnDto> GetUserById(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) throw new UserNotFoundException(userId);

			var returnUser = mapper.Map<UserReturnDto>(user);
			returnUser.Roles = userManager.GetRolesAsync(user).Result.ToList();

			return returnUser;
		}

		public async Task<IEnumerable<UserReturnDto>> GetUsers()
		{
			var users = await userManager.Users.ToListAsync();
			var returnUsers = mapper.Map<IEnumerable<UserReturnDto>>(users);
			returnUsers = returnUsers.Select(user =>
			{
				user.Roles = userManager.GetRolesAsync(users.FirstOrDefault(u => u.Id == user.Id)).Result.ToList();
				return user;
			}).Where(c => !c.Roles.Contains(Roles.Admin));
			return returnUsers;
		}

		public async Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			return await userManager.ChangePasswordAsync(user, userForUpdatePasswordDto.OldPassword, userForUpdatePasswordDto.NewPassword);
		}

		public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
		{
			var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

			var user = await userManager.FindByNameAsync(principal.FindFirstValue("Username"));
			if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now) throw new RefreshTokenBadRequest();

			this.user = user;

			return await CreateToken(false);
		}
	}
}
