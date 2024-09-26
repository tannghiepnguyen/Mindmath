using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Domain.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class InputParameterConfiguration : IEntityTypeConfiguration<InputParameter>
	{
		public void Configure(EntityTypeBuilder<InputParameter> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Input).IsRequired();
			builder.Property(e => e.CreatedAt).IsRequired();
			builder.Property(e => e.UpdateAt).IsRequired();
			builder.Property(e => e.Active).IsRequired();
			builder.HasOne(e => e.ProblemType).WithMany(e => e.InputParameters).HasForeignKey(e => e.ProblemTypeId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
