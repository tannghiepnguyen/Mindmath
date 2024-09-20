using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Domain.Constant;

namespace Mindmath.Infrastructure.Configuration
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Name = Roles.Admin,
					NormalizedName = Roles.Admin.ToUpper()
				},
				new IdentityRole
				{
					Name = Roles.Teacher,
					NormalizedName = Roles.Teacher.ToUpper()
				}
			);
		}
	}
}
