using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Repository.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
	{
		public void Configure(EntityTypeBuilder<Chapter> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.Property(x => x.UpdatedAt).IsRequired();
			builder.Property(x => x.Active).IsRequired();
			builder.HasOne(x => x.Subject).WithMany(x => x.Chapters).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new Chapter()
				{
					Id = Guid.Parse("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
					Name = "Trigonometry",
					Description = "This chapter deals with trigonometry and its applications in solving problems related to triangles and other geometric shapes.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Active = true,
					SubjectId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				},
				new Chapter()
				{
					Id = Guid.Parse("93d95c83-6594-465d-a906-7f8f899a2bfc"),
					Name = "Calculus",
					Description = "This chapter deals with calculus and its applications in solving problems related to rates of change and accumulation.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Active = true,
					SubjectId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				},
				new Chapter()
				{
					Id = Guid.Parse("564396d4-d864-49c2-a16c-122114f2e9b4"),
					Name = "Algebra",
					Description = "This chapter deals with algebra and its applications in solving problems related to equations and inequalities.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Active = true,
					SubjectId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				},
				new Chapter()
				{
					Id = Guid.Parse("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
					Name = "Geometry",
					Description = "This chapter is a branch of mathematics that deals with the properties, relationships, and measurements of points, lines, shapes, and spaces. It is one of the oldest fields of mathematics and has wide applications in various fields, from art and architecture to engineering and physics",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Active = true,
					SubjectId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				}
			);
		}
	}
}