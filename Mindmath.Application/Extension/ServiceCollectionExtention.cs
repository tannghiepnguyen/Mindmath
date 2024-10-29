using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Mindmath.Service.IService;
using Mindmath.Service.Service;

namespace Mindmath.Service.Extension
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

		public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

		public static void ConfigureReceiverService(this IServiceCollection services) => services.AddHostedService<ReceiverService>();

		public static void AddBlobService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(u => new BlobServiceClient(configuration.GetConnectionString("StorageAccount")));
			services.AddSingleton<IBlobService, BlobService>();
		}
	}
}
