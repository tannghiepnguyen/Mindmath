using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;

namespace Mindmath.Repository.IRepository
{
	public interface IProblemTypeRepository
	{
		Task<PagedList<ProblemType>> GetProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange);
		Task<PagedList<ProblemType>> GetActiveProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange);
		Task<ProblemType?> GetProblemType(Guid topicId, Guid id, bool trackChange);
		Task<ProblemType?> GetProblemType(Guid id, bool trackChange);
		void CreateProblemType(ProblemType problemType);
	}
}
