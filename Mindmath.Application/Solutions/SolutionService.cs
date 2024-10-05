using AutoMapper;
using Mindmath.Repository.IRepository;
using Mindmath.Service.Solutions.DTO;

namespace Mindmath.Service.Solutions
{
	public class SolutionService : ISolutionService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public SolutionService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}

		//private async Task CheckInputParameterExist(Guid inputParameterId, bool trackChange)
		//{
		//	//var inputParameter = await repositoryManager.InputParameters.GetInputParameter(inputParameterId, trackChange);
		//	//if (inputParameter == null) throw new InputParameterNotFoundException(inputParameterId);
		//}

		public Task<SolutionReturnDto> GetSolutionByInputParameterId(Guid inputParameterId, bool trackChange)
		{
			throw new NotImplementedException();
		}
	}
}
