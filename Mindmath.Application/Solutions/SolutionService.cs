using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Service.Solutions.DTO;

namespace Mindmath.Service.Solutions
{
	internal sealed class SolutionService : ISolutionService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public SolutionService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}

		private async Task CheckInputParameterExist(Guid inputParameterId, bool trackChange)
		{
			var inputParameter = await repositoryManager.InputParameters.GetInputParameter(inputParameterId, trackChange);
			if (inputParameter == null) throw new InputParameterNotFoundException(inputParameterId);
		}

		public async Task<SolutionReturnDto> GetSolutionByInputParameterId(Guid inputParameterId, bool trackChange)
		{
			await CheckInputParameterExist(inputParameterId, trackChange);

			var solution = await repositoryManager.Solutions.GetSolutionByInputParameterId(inputParameterId, trackChange);
			if (solution == null) throw new SolutionNotFoundException(inputParameterId);

			return mapper.Map<SolutionReturnDto>(solution);
		}
	}
}
