using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mindmath.Application.Users.DTO;
using Mindmath.Domain.Constant;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

		public async Task<string> CreateToken()
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims();
			var token = GenerateTokenOptions(signingCredentials, claims);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private SecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenOptions = new JwtSecurityToken(
				issuer: jwtSettings.GetSection("validIssuer").Value,
				audience: jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				signingCredentials: signingCredentials
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
				claims.Add(new Claim("Roles", role));
			}
			claims.Add(new Claim("Fullname", user.Fullname));
			claims.Add(new Claim("Id", user.Id));
			claims.Add(new Claim("Avatar", user.Avatar));
			claims.Add(new Claim("Email", user.Email));
			claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
			claims.Add(new Claim("Gender", user.Gender));
			claims.Add(new Claim("DateOfBirth", user.DateOfBirth.ToString()));
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
			user.CreateAt = DateOnly.FromDateTime(DateTime.Now);
			user.UpdateAt = DateOnly.FromDateTime(DateTime.Now);
			user.Avatar = string.Empty;
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

			if (!result)
			{

			}
			return result;
		}
	}
}
