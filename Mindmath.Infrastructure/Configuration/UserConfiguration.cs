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
			builder.Property(u => u.CreatedAt);
			builder.Property(u => u.UpdatedAt);
			builder.Property(u => u.DeletedAt);
			builder.Property(u => u.Active).IsRequired();
			builder.Property(u => u.Avatar);
			builder.Property(u => u.RefreshToken).IsRequired();
			builder.Property(u => u.RefreshTokenExpiryTime).IsRequired();
			builder.HasOne(u => u.Wallet).WithOne(u => u.User).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(u => u.InputParameters).WithOne(u => u.User).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(u => u.Transactions).WithOne(u => u.User).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
