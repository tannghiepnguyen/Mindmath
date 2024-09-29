using AutoMapper;
using Mindmath.Application.ProblemTypes.DTO;
using Mindmath.Domain.Exceptions;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;

namespace Mindmath.Application.ProblemTypes
{
	internal sealed class ProblemTypeService : IProblemTypeService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public ProblemTypeService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}
		private async Task CheckTopicExist(Guid topicId, bool trackChange)
		{
			var topic = await repositoryManager.Topics.GetTopic(topicId, trackChange);
			if (topic == null) throw new TopicNotFoundException(topicId);
		}
		public async Task<ProblemTypeReturnDto> CreateProblemType(Guid topicId, ProblemTypeForCreationDto problemType, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var problemTypeEntity = mapper.Map<ProblemType>(problemType);
			problemTypeEntity.Id = Guid.NewGuid();
			problemTypeEntity.CreatedAt = DateTime.Now;
			problemTypeEntity.UpdatedAt = DateTime.Now;
			problemTypeEntity.Active = true;

			repositoryManager.ProblemTypes.CreateProblemType(topicId, problemTypeEntity);
			await repositoryManager.Save();
			return mapper.Map<ProblemTypeReturnDto>(problemTypeEntity);
		}

		public async Task<IEnumerable<ProblemTypeReturnDto>> GetActiveProblemTypes(Guid topicId, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var activeProblemTypes = await repositoryManager.ProblemTypes.GetActiveProblemTypes(topicId, trackChange);
			return mapper.Map<IEnumerable<ProblemTypeReturnDto>>(activeProblemTypes);
		}

		public async Task<ProblemTypeReturnDto?> GetProblemType(Guid topicId, Guid id, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var problemType = await repositoryManager.ProblemTypes.GetProblemType(topicId, id, trackChange);
			if (problemType == null) throw new ProblemTypeNotFoundException(id);

			return mapper.Map<ProblemTypeReturnDto?>(problemType);
		}

		public async Task<IEnumerable<ProblemTypeReturnDto>> GetProblemTypes(Guid topicId, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var problemTypes = await repositoryManager.ProblemTypes.GetProblemTypes(topicId, trackChange);
			return mapper.Map<IEnumerable<ProblemTypeReturnDto>>(problemTypes);
		}

		public async Task UpdateProblemType(Guid topicId, Guid id, ProblemTypeForUpdateDto problemTypeForUpdate, bool topicTrackChange, bool problemTypeTrackChange)
		{
			await CheckTopicExist(topicId, topicTrackChange);

			var problemType = await repositoryManager.ProblemTypes.GetProblemType(topicId, id, problemTypeTrackChange);
			if (problemType == null) throw new ProblemTypeNotFoundException(id);

			mapper.Map(problemTypeForUpdate, problemType);
			problemType.UpdatedAt = DateTime.Now;
			await repositoryManager.Save();
		}
	}
}
