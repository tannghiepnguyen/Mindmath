using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mindmath.Domain.Models;

namespace Mindmath.Infrastructure.Configuration
{
	public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.CreatedAt).IsRequired();
			builder.Property(x => x.UpdatedAt).IsRequired();
			builder.Property(x => x.Active).IsRequired();

			builder.HasData(
				new Subject()
				{
					Id = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
					Name = "Mathematics",
					Description = "The study of numbers, quantities, structures, shapes, space, and change. It involves abstract concepts as well as practical problem-solving techniques that are essential in various fields such as science, engineering, economics, and more.",
					CreatedAt = new DateOnly(2021, 10, 1),
					UpdatedAt = new DateOnly(2021, 10, 1),
					Active = true
				}
			);
		}
	}
}