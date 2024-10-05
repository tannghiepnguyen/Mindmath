using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

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
			builder.Property(e => e.Active).IsRequired();
			builder.HasOne(e => e.Topic).WithMany(e => e.ProblemTypes).HasForeignKey(e => e.TopicId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(e => e.InputParameters).WithOne(e => e.ProblemType).OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new ProblemType()
				{
					Id = Guid.Parse("63451f88-8285-4f88-97b1-96d1ec42e53e"),
					Name = "Minimum and Maximum",
					Description = "These problems involve finding whether the function has a maximum or minimum value by analyzing the vertex of the parabola. If a>0, the vertex is a minimum; if a<0, the vertex is a maximum. Students are often asked to interpret these values in the context of real-world scenarios.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Active = true,
					TopicId = Guid.Parse("92ad3091-6df7-4da0-9899-45ad92d06b51")
				}
			);
		}
	}
}
