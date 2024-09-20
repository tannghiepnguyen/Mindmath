using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Domain.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class TopicConfiguration : IEntityTypeConfiguration<Topic>
	{
		public void Configure(EntityTypeBuilder<Topic> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
			builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
			builder.Property(t => t.CreatedAt).IsRequired();
			builder.Property(t => t.UpdatedAt).IsRequired();
			builder.Property(t => t.Status).IsRequired();
			builder.HasOne(t => t.Chapter).WithMany(c => c.Topics).HasForeignKey(t => t.ChapterId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
