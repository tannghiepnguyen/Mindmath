using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Domain.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
	{
		public void Configure(EntityTypeBuilder<Chapter> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.NumberOfTopic).IsRequired();
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.Property(x => x.UpdatedAt).IsRequired();
			builder.Property(x => x.Status).IsRequired();
			builder.HasOne(x => x.Subject).WithMany(x => x.Chapters).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}