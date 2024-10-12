using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(u => u.Fullname).HasMaxLength(100).IsRequired();
			builder.Property(u => u.CreateAt).IsRequired();
			builder.Property(u => u.UpdateAt).IsRequired();
			builder.Property(u => u.Active).IsRequired();
			builder.Property(u => u.RefreshToken).IsRequired();
			builder.Property(u => u.RefreshTokenExpiryTime).IsRequired();
			builder.HasOne(u => u.Wallet).WithOne(u => u.User).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(u => u.InputParameters).WithOne(u => u.User).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
