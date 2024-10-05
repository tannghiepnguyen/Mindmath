using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
	{
		public void Configure(EntityTypeBuilder<Wallet> builder)
		{
			builder.HasKey(w => w.Id);
			builder.Property(w => w.Balance).IsRequired();
			builder.HasOne(w => w.User).WithOne(u => u.Wallet).HasForeignKey<Wallet>(w => w.UserId);
		}
	}
}
