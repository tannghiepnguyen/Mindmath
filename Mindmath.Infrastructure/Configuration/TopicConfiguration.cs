using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class TopicConfiguration : IEntityTypeConfiguration<Topic>
	{
		public void Configure(EntityTypeBuilder<Topic> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
			builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
			builder.Property(t => t.CreatedAt);
			builder.Property(t => t.UpdatedAt);
			builder.Property(t => t.DeletedAt);
			builder.Property(t => t.Active).IsRequired();
			builder.HasOne(t => t.Chapter).WithMany(c => c.Topics).HasForeignKey(t => t.ChapterId).OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new Topic()
				{
					Id = Guid.Parse("3e552a68-c165-4007-a361-adc57e728193"),
					Name = "Equations and Inequalities",
					Description = "Covers solving linear equations and inequalities. Focuses on understanding equality and inequality symbols and how to manipulate equations to isolate variables.",
					CreatedAt = DateTime.Now,
					Active = true,
					ChapterId = Guid.Parse("564396d4-d864-49c2-a16c-122114f2e9b4")
				},
				new Topic()
				{
					Id = Guid.Parse("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
					Name = "Linear Equations",
					Description = "Deals with equations involving two variables. Focuses on graphing these equations on a coordinate plane and understanding their geometric interpretation.",
					CreatedAt = DateTime.Now,
					Active = true,
					ChapterId = Guid.Parse("564396d4-d864-49c2-a16c-122114f2e9b4")
				},
				new Topic()
				{
					Id = Guid.Parse("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
					Name = "Quadratic Equations",
					Description = "Introduction to quadratic equations and methods for solving them such as factoring, completing the square, and using the quadratic formula.",
					CreatedAt = DateTime.Now,
					Active = true,
					ChapterId = Guid.Parse("564396d4-d864-49c2-a16c-122114f2e9b4")
				},
				new Topic()
				{
					Id = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
					Name = "Triangles",
					Description = "Explains the classification of triangles based on sides (equilateral, isosceles, scalene) and angles (acute, obtuse, right). It also introduces the properties of triangles and the Triangle Inequality Theorem.",
					CreatedAt = DateTime.Now,
					Active = true,
					ChapterId = Guid.Parse("32c1e4f7-36fc-44b8-9476-b2ac48f4504a")
				},
				new Topic()
				{
					Id = Guid.Parse("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
					Name = "Circles",
					Description = "Explains the properties of circles, including radius, diameter, chord, tangent, secant, arc, and sector. Covers important theorems related to angles in circles, such as the Inscribed Angle Theorem and Tangent-Secant Theorem.",
					CreatedAt = DateTime.Now,
					Active = true,
					ChapterId = Guid.Parse("32c1e4f7-36fc-44b8-9476-b2ac48f4504a")
				}
			);
		}
	}
}
