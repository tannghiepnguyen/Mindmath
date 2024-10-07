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
			builder.Property(e => e.NumberOfInputs).IsRequired();
			builder.Property(e => e.Active).IsRequired();
			builder.HasOne(e => e.Topic).WithMany(e => e.ProblemTypes).HasForeignKey(e => e.TopicId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(e => e.InputParameters).WithOne(e => e.ProblemType).OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new ProblemType()
				{
					Id = Guid.Parse("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
					Name = "Circumference of a Circle",
					Description = "Use the formula to find the circumference.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					NumberOfInputs = 1,
					Active = true,
					TopicId = Guid.Parse("37f7aef3-f5ec-4f95-bc88-ab929877b3d5")
				},
				new ProblemType()
				{
					Id = Guid.Parse("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
					Name = "Area of a Circle",
					Description = "Use the formula to find the area.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					NumberOfInputs = 1,
					Active = true,
					TopicId = Guid.Parse("37f7aef3-f5ec-4f95-bc88-ab929877b3d5")
				},
				new ProblemType()
				{
					Id = Guid.Parse("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
					Name = "Perimeter of a triangle",
					Description = "Use the formula to find the perimeter.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					NumberOfInputs = 3,
					Active = true,
					TopicId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				},
				new ProblemType()
				{
					Id = Guid.Parse("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
					Name = "Area of a triangle",
					Description = "Use the formula to find the area.",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					NumberOfInputs = 2,
					Active = true,
					TopicId = Guid.Parse("f5a42f20-64ef-43b6-aeef-a4686a3b19dd")
				}
			);
		}
	}
}
