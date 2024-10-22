using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class InputParameterConfiguration : IEntityTypeConfiguration<InputParameter>
	{
		public void Configure(EntityTypeBuilder<InputParameter> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Input).IsRequired();
			builder.Property(e => e.CreatedAt);
			builder.Property(e => e.UpdatedAt);
			builder.Property(e => e.DeletedAt);
			builder.Property(e => e.Active).IsRequired();
			builder.HasOne(e => e.ProblemType).WithMany(e => e.InputParameters).HasForeignKey(e => e.ProblemTypeId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(e => e.User).WithMany(e => e.InputParameters).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
