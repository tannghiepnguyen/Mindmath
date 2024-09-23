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
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.Property(x => x.UpdatedAt).IsRequired();
			builder.Property(x => x.Status).IsRequired();
			builder.HasOne(x => x.Subject).WithMany(x => x.Chapters).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new Chapter()
				{
					Id = Guid.Parse("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
					Name = "Quadratic Equations",
					Description = "This chapter deals with quadratic equations and their solutions using different methods such as factorization, completing the square, and the quadratic formula.",
					CreatedAt = new DateOnly(2021, 10, 1),
					UpdatedAt = new DateOnly(2021, 10, 1),
					Status = true,
					SubjectId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				}
			);
		}
	}
}