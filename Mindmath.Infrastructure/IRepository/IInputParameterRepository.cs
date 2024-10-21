using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;

namespace Mindmath.Repository.IRepository
{
	public interface IInputParameterRepository
	{
		void CreateInputParameter(InputParameter inputParameter);
		Task<InputParameter?> GetInputParameter(string userId, Guid problemTypeId, Guid inputParameterId, bool trackChange);
		Task<InputParameter?> GetInputParameter(Guid inputParameterId, bool trackChange);
		Task<PagedList<InputParameter>> GetInputParameters(string userId, Guid problemTypeId, InputParameterParameters inputParameterParameters, bool trackChange);
		Task<PagedList<InputParameter>> GetActiveInputParameters(string userId, Guid problemTypeId, InputParameterParameters inputParameterParameters, bool trackChange);

	}
}
