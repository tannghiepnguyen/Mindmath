using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface IProblemTypeRepository
	{
		Task<IEnumerable<ProblemType>> GetProblemTypes(Guid topicId, bool trackChange);
		Task<IEnumerable<ProblemType>> GetActiveProblemTypes(Guid topicId, bool trackChange);
		Task<ProblemType?> GetProblemType(Guid topicId, Guid id, bool trackChange);
		Task<ProblemType?> GetProblemType(Guid id, bool trackChange);
		void CreateProblemType(ProblemType problemType);
	}
}
