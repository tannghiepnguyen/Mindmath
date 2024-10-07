using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
	{
		public void Configure(EntityTypeBuilder<Deposit> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Amount).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.HasOne(x => x.User).WithMany(x => x.Deposits).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
