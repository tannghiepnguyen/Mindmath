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
			builder.Property(t => t.Active).IsRequired();
			builder.HasOne(t => t.Chapter).WithMany(c => c.Topics).HasForeignKey(t => t.ChapterId).OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new Topic()
				{
					Id = Guid.Parse("92ad3091-6df7-4da0-9899-45ad92d06b51"),
					Name = "Graph of a Quadratic Function",
					Description = "Focuses on the shape of the graph of quadratic functions, known as parabolas. It explains how to graph a quadratic function and how the coefficients a, b, c affect the shape and position of the parabola. The section highlights the vertex and axis of symmetry",
					CreatedAt = new DateOnly(2021, 10, 1),
					UpdatedAt = new DateOnly(2021, 10, 1),
					Active = true,
					ChapterId = Guid.Parse("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
				}
			);
		}
	}
}
