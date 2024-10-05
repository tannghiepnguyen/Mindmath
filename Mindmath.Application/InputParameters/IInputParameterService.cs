using Mindmath.Service.InputParameters.DTO;

namespace Mindmath.Service.InputParameters
{
	public interface IInputParameterService
	{
		Task<InputParameterReturnDto> CreateInputParameter(InputParameterForCreationDto inputParameter, Guid problemTypeId, string userId, bool trackChange);
		Task UpdateInputParameter(Guid problemTypeId, string userId, Guid inputParameterId, InputParameterForUpdateDto inputParameter, bool inputParameterTrackChange, bool problemTypeTrackChange);
		Task<InputParameterReturnDto?> GetInputParameter(Guid problemTypeId, string userId, Guid inputParameterId, bool trackChange);

		Task<IEnumerable<InputParameterReturnDto>> GetInputParameters(Guid problemTypeId, string userId, bool trackChange);
		Task<IEnumerable<InputParameterReturnDto>> GetActiveInputParameters(Guid problemTypeId, string userId, bool trackChange);

	}
}
