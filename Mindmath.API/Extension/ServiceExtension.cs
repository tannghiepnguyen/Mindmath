using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mindmath.Infrastructure.Repository;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.Persistence;

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
						.AllowAnyHeader()
						.WithExposedHeaders("X-Pagination");
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
				o.Password.RequireLowercase = false;
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
