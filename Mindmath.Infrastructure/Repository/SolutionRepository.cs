using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	public class SolutionRepository : RepositoryBase<Solution>, ISolutionRepository
	{
		public SolutionRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateSolution(Solution solution) => Create(solution);

		public async Task<Solution?> GetSolutionByInputParameterId(Guid inputParameterId, bool trackChange) => await FindByCondition(s => s.InputParameterId.Equals(inputParameterId), trackChange).FirstOrDefaultAsync();
	}
}
