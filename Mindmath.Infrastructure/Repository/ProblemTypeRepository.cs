using Microsoft.EntityFrameworkCore;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class ProblemTypeRepository : RepositoryBase<ProblemType>, IProblemTypeRepository
	{
		public ProblemTypeRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateProblemType(Guid topicId, ProblemType problemType)
		{
			problemType.TopicId = topicId;
			Create(problemType);
		}

		public async Task<IEnumerable<ProblemType>> GetActiveProblemTypes(Guid topicId, bool trackChange) =>
			await FindByCondition(x => x.TopicId == topicId && x.Active, trackChange).ToListAsync();

		public async Task<ProblemType?> GetProblemType(Guid topicId, Guid id, bool trackChange) =>
			await FindByCondition(x => x.TopicId == topicId && x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<ProblemType?> GetProblemType(Guid id, bool trackChange) => await FindByCondition(x => x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<ProblemType>> GetProblemTypes(Guid topicId, bool trackChange) =>
			await FindByCondition(x => x.TopicId == topicId, trackChange).ToListAsync();
	}
}
