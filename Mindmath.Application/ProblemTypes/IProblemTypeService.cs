using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.ProblemTypes.DTO;

namespace Mindmath.Service.ProblemTypes
{
	public interface IProblemTypeService
	{
		Task<(IEnumerable<ProblemTypeReturnDto> problemTypes, MetaData metaData)> GetProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange);
		Task<(IEnumerable<ProblemTypeReturnDto> problemTypes, MetaData metaData)> GetActiveProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange);
		Task<ProblemTypeReturnDto?> GetProblemType(Guid topicId, Guid id, bool trackChange);
		Task<ProblemTypeReturnDto> CreateProblemType(Guid topicId, ProblemTypeForCreationDto problemType, bool trackChange);
		Task UpdateProblemType(Guid topicId, Guid id, ProblemTypeForUpdateDto problemTypeForUpdate, bool topicTrackChange, bool problemTypeTrackChange);
		Task DeleteProblemType(Guid topicId, Guid id, bool topicTrackChange, bool problemTypeTrackChange);
	}
}
