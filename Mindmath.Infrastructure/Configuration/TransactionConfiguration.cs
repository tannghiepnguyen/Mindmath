using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;


namespace Mindmath.Infrastructure.Configuration
{
	public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
	{
		public void Configure(EntityTypeBuilder<Transaction> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Amount).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.HasOne(x => x.Wallet).WithMany(x => x.Transactions).HasForeignKey(x => x.WalletId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
