using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.IService;
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
		private readonly IBlobService blobService;
		private User? user;

		public AuthenticationService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IRepositoryManager repositoryManager, IBlobService blobService)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.configuration = configuration;
			this.roleManager = roleManager;
			this.repositoryManager = repositoryManager;
			this.blobService = blobService;
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
			claims.Add(new Claim("Avatar", user.Avatar));
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
			user.CreatedAt = DateTime.Now;
			user.Active = true;
			user.Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=";

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

			return (user != null && await userManager.CheckPasswordAsync(user, userForAuthentication.Password) && user.Active);
		}

		public async Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdateDto)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			mapper.Map(userForUpdateDto, user);
			user.UpdatedAt = DateTime.Now;
			if (userForUpdateDto.File is not null && userForUpdateDto.File.Length > 0)
			{
				await blobService.DeleteBlob(user.Avatar.Split('/').Last(), StorageContainer.STORAGE_CONTAINER);
				string filename = $"{Guid.NewGuid()}{Path.GetExtension(userForUpdateDto.File.FileName)}";
				user.Avatar = await blobService.UploadBlob(filename, StorageContainer.STORAGE_CONTAINER, userForUpdateDto.File);
			}

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

		public async Task<(IEnumerable<UserReturnDto> users, MetaData MetaData)> GetUsers(UserParameters userParameters)
		{
			var usersMetaData = PagedList<User>.ToPagedList(userManager.Users.Where(c => !c.UserName.Equals("admin")), userParameters.PageNumber, userParameters.PageSize);
			var returnUsers = mapper.Map<IEnumerable<UserReturnDto>>(usersMetaData);
			returnUsers = returnUsers.Select(user =>
			{
				user.Roles = userManager.GetRolesAsync(usersMetaData.Find(u => u.Id == user.Id)).Result.ToList();
				return user;
			}).Where(c => !c.Roles.Contains(Roles.Admin));
			return (returnUsers, usersMetaData.MetaData);
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

		public async Task<IdentityResult> UpdateUserActive(string userId, bool active)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			user.Active = active;
			user.UpdatedAt = DateTime.Now;

			return await userManager.UpdateAsync(user);
		}
	}
}
