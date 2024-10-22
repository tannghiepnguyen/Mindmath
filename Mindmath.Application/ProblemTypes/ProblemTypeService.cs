using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.ProblemTypes.DTO;

namespace Mindmath.Service.ProblemTypes
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
			problemTypeEntity.TopicId = topicId;

			repositoryManager.ProblemTypes.CreateProblemType(problemTypeEntity);
			await repositoryManager.Save();
			return mapper.Map<ProblemTypeReturnDto>(problemTypeEntity);
		}

		public async Task<(IEnumerable<ProblemTypeReturnDto> problemTypes, MetaData metaData)> GetActiveProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var activeProblemTypesMetaData = await repositoryManager.ProblemTypes.GetActiveProblemTypes(topicId, problemTypeParameters, trackChange);
			var activeProblemTypes = mapper.Map<IEnumerable<ProblemTypeReturnDto>>(activeProblemTypesMetaData);
			return (activeProblemTypes, activeProblemTypesMetaData.MetaData);
		}

		public async Task<ProblemTypeReturnDto?> GetProblemType(Guid topicId, Guid id, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var problemType = await repositoryManager.ProblemTypes.GetProblemType(topicId, id, trackChange);
			if (problemType == null) throw new ProblemTypeNotFoundException(id);

			return mapper.Map<ProblemTypeReturnDto?>(problemType);
		}

		public async Task<(IEnumerable<ProblemTypeReturnDto> problemTypes, MetaData metaData)> GetProblemTypes(Guid topicId, ProblemTypeParameters problemTypeParameters, bool trackChange)
		{
			await CheckTopicExist(topicId, trackChange);

			var activeProblemTypesMetaData = await repositoryManager.ProblemTypes.GetProblemTypes(topicId, problemTypeParameters, trackChange);
			var activeProblemTypes = mapper.Map<IEnumerable<ProblemTypeReturnDto>>(activeProblemTypesMetaData);
			return (activeProblemTypes, activeProblemTypesMetaData.MetaData);
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

		public async Task DeleteProblemType(Guid topicId, Guid id, bool topicTrackChange, bool problemTypeTrackChange)
		{
			await CheckTopicExist(topicId, topicTrackChange);

			var problemType = await repositoryManager.ProblemTypes.GetProblemType(topicId, id, problemTypeTrackChange);
			if (problemType == null) throw new ProblemTypeNotFoundException(id);

			problemType.Active = false;
			problemType.DeletedAt = DateTime.Now;
			await repositoryManager.Save();
		}
	}
}
