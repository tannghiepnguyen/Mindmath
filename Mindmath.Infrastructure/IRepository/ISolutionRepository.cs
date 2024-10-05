using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface ISolutionRepository
	{
		void CreateSolution(Solution solution);
		Task<Solution?> GetSolutionByInputParameterId(Guid inputParameterId, bool trackChange);
	}
}
