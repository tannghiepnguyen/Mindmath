using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;
using Mindmath.Infrastructure.Repository;

namespace Mindmath.API.Extension
{
	public static class ServiceExtension
	{
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});
		}

		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MindmathDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("MindmathDb")));
		}

		public static void ConfigureRepositorymanager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

		public static void ConfigureIdentity(this IServiceCollection services)
		{
			services.AddIdentity<User, IdentityRole>(o =>
			{
				o.Password.RequireDigit = false;
				o.Password.RequireLowercase = true;
				o.Password.RequireUppercase = false;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 5;
				o.User.RequireUniqueEmail = true;
			})
				.AddEntityFrameworkStores<MindmathDbContext>()
				.AddDefaultTokenProviders();
		}
	}
}
