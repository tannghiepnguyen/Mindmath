using Mindmath.Service.Solutions.DTO;

namespace Mindmath.Service.Solutions
{
	public interface ISolutionService
	{
		Task<SolutionReturnDto> GetSolutionByInputParameterId(Guid inputParameterId, bool trackChange);
	}
}
