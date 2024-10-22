using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.InputParameters.DTO;

namespace Mindmath.Service.InputParameters
{
	public interface IInputParameterService
	{
		Task<InputParameterReturnDto> CreateInputParameter(InputParameterForCreationDto inputParameter, Guid problemTypeId, string userId, bool trackChange);
		Task DeleteInputParameter(Guid problemTypeId, string userId, Guid inputParameterId, bool inputParameterTrackChange, bool problemTypeTrackChange);
		Task<InputParameterReturnDto?> GetInputParameter(Guid problemTypeId, string userId, Guid inputParameterId, bool trackChange);

		Task<(IEnumerable<InputParameterReturnDto> inputParameters, MetaData metaData)> GetInputParameters(Guid problemTypeId, string userId, InputParameterParameters inputParameterParameters, bool trackChange);
		Task<(IEnumerable<InputParameterReturnDto> inputParameters, MetaData metaData)> GetActiveInputParameters(Guid problemTypeId, string userId, InputParameterParameters inputParameterParameters, bool trackChange);

	}
}
