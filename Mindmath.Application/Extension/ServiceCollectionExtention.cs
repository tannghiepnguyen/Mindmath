using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Mindmath.Application.IService;
using Mindmath.Application.Service;

namespace Mindmath.Application.Extension
{
	public static class ServiceCollectionExtention
	{
		public static void AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddAutoMapper(typeof(ServiceCollectionExtention).Assembly);
		}

		public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(o =>
				{
					o.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = false,
						ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
						ValidAudience = jwtSettings.GetSection("validAudience").Value,
						IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.GetSection("secret").Value))
					};
				});
		}
	}
}
