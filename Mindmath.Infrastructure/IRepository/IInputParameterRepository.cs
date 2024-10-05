using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface IInputParameterRepository
	{
		void CreateInputParameter(InputParameter inputParameter);
		Task<InputParameter?> GetInputParameter(string userId, Guid problemTypeId, Guid inputParameterId, bool trackChange);
		Task<IEnumerable<InputParameter>> GetInputParameters(string userId, Guid problemTypeId, bool trackChange);
		Task<IEnumerable<InputParameter>> GetActiveInputParameters(string userId, Guid problemTypeId, bool trackChange);

	}
}
