using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class ProblemTypeRepository : RepositoryBase<ProblemType>, IProblemTypeRepository
	{
		public ProblemTypeRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateProblemType(ProblemType problemType) => Create(problemType);

		public async Task<PagedList<ProblemType>> GetActiveProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange)
		{
			var problemTypes = FindByCondition(x => x.TopicId == topicId && x.Active, trackChange).OrderBy(c => c.Name);
			return PagedList<ProblemType>.ToPagedList(problemTypes, problemTypeParameters.PageNumber, problemTypeParameters.PageSize);
		}

		public async Task<ProblemType?> GetProblemType(Guid topicId, Guid id, bool trackChange) =>
			await FindByCondition(x => x.TopicId == topicId && x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<ProblemType?> GetProblemType(Guid id, bool trackChange) => await FindByCondition(x => x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<ProblemType>> GetProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange)
		{
			var problemTypes = FindByCondition(x => x.TopicId == topicId, trackChange).OrderBy(c => c.Name);
			return PagedList<ProblemType>.ToPagedList(problemTypes, problemTypeParameters.PageNumber, problemTypeParameters.PageSize);
		}
	}
}
