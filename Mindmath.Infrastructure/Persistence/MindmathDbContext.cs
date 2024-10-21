using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mindmath.Infrastructure.Configuration;
using Mindmath.Repository.Models;

namespace Mindmath.Repository.Persistence
{
	public class MindmathDbContext : IdentityDbContext
	{
		public MindmathDbContext(DbContextOptions<MindmathDbContext> options) : base(options)
		{
		}
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<ProblemType> ProblemTypes { get; set; }
		public DbSet<InputParameter> InputParameters { get; set; }
		public DbSet<Solution> Solution { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new SubjectConfiguration());
			builder.ApplyConfiguration(new ChapterConfiguration());
			builder.ApplyConfiguration(new TopicConfiguration());
			builder.ApplyConfiguration(new ProblemTypeConfiguration());
			builder.ApplyConfiguration(new InputParameterConfiguration());
			builder.ApplyConfiguration(new WalletConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new SolutionConfiguration());
			builder.ApplyConfiguration(new TransactionConfiguration());
			builder.ApplyConfiguration(new RoleConfiguration());

			var admin = new User
			{
				Id = "a4a224cf-972f-4a97-bf9f-393896af2a0b",
				UserName = "admin",
				Email = "admin@gmail.com",
				Fullname = "Nguyen Le Tan Nghiep",
				PhoneNumber = "0908918318"
			};
			admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "admin");

			var adminRoles = new List<IdentityUserRole<string>> {
				new IdentityUserRole<string> { UserId = admin.Id, RoleId = "e2c41f1e-bc94-42f8-beb5-10d3a2a406dd" },
				new IdentityUserRole<string> { UserId = admin.Id, RoleId = "ab84eb31-7aaa-4e44-8aa9-409be54014c8" }
			};

			builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
		}
	}
}
