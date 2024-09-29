using Mindmath.Application.ProblemTypes.DTO;

namespace Mindmath.Application.ProblemTypes
{
	public interface IProblemTypeService
	{
		Task<IEnumerable<ProblemTypeReturnDto>> GetProblemTypes(Guid topicId, bool trackChange);
		Task<IEnumerable<ProblemTypeReturnDto>> GetActiveProblemTypes(Guid topicId, bool trackChange);
		Task<ProblemTypeReturnDto?> GetProblemType(Guid topicId, Guid id, bool trackChange);
		Task<ProblemTypeReturnDto> CreateProblemType(Guid topicId, ProblemTypeForCreationDto problemType, bool trackChange);
		Task UpdateProblemType(Guid topicId, Guid id, ProblemTypeForUpdateDto problemTypeForUpdate, bool topicTrackChange, bool problemTypeTrackChange);
	}
}
