using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Domain.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class ProblemTypeConfiguration : IEntityTypeConfiguration<ProblemType>
	{
		public void Configure(EntityTypeBuilder<ProblemType> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Name).IsRequired();
			builder.Property(e => e.Description).IsRequired();
			builder.Property(e => e.CreatedAt).IsRequired();
			builder.Property(e => e.UpdatedAt).IsRequired();
			builder.HasOne(e => e.Topic).WithMany(e => e.ProblemTypes).HasForeignKey(e => e.TopicId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(e => e.Solutions).WithOne(e => e.ProblemType).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
