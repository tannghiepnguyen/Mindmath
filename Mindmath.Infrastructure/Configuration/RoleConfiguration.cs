using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Constant;

namespace Mindmath.Infrastructure.Configuration
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Id = "e2c41f1e-bc94-42f8-beb5-10d3a2a406dd",
					Name = Roles.Admin,
					NormalizedName = Roles.Admin.ToUpper()
				},
				new IdentityRole
				{
					Id = "ab84eb31-7aaa-4e44-8aa9-409be54014c8",
					Name = Roles.Teacher,
					NormalizedName = Roles.Teacher.ToUpper()
				}
			);
		}
	}
}
