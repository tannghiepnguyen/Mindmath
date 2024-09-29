using Mindmath.Domain.Models;

namespace Mindmath.Domain.Repository
{
	public interface IProblemTypeRepository
	{
		Task<IEnumerable<ProblemType>> GetProblemTypes(Guid topicId, bool trackChange);
		Task<IEnumerable<ProblemType>> GetActiveProblemTypes(Guid topicId, bool trackChange);
		Task<ProblemType?> GetProblemType(Guid topicId, Guid id, bool trackChange);
		Task<ProblemType?> GetProblemType(Guid id, bool trackChange);
		void CreateProblemType(Guid topicId, ProblemType problemType);
	}
}
