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
		}
	}
}
