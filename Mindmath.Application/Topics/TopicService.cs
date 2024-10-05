using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Service.Topics.DTO;

namespace Mindmath.Service.Topics
{
	internal sealed class TopicService : ITopicService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public TopicService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}

		private async Task CheckChapterExist(Guid chapterId, bool trackChange)
		{
			var chapter = await repositoryManager.Chapters.GetChapter(chapterId, trackChange);
			if (chapter == null) throw new ChapterNotFoundException(chapterId);
		}
		public async Task<TopicReturnDto> CreateTopic(Guid chapterId, TopicForCreationDto topic, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var topicEntity = mapper.Map<Topic>(topic);
			topicEntity.Id = Guid.NewGuid();
			topicEntity.CreatedAt = DateTime.Now;
			topicEntity.UpdatedAt = DateTime.Now;
			topicEntity.Active = true;
			topicEntity.ChapterId = chapterId;
			repositoryManager.Topics.CreateTopic(topicEntity);
			await repositoryManager.Save();
			return mapper.Map<TopicReturnDto>(topicEntity);
		}

		public async Task<IEnumerable<TopicReturnDto>> GetActiveTopics(Guid chapterId, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var activeTopics = await repositoryManager.Topics.GetActiveTopics(chapterId, trackChange);
			return mapper.Map<IEnumerable<TopicReturnDto>>(activeTopics);
		}

		public async Task<TopicReturnDto?> GetTopic(Guid chapterId, Guid id, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var topic = await repositoryManager.Topics.GetTopic(chapterId, id, trackChange);
			if (topic == null) throw new TopicNotFoundException(id);

			return mapper.Map<TopicReturnDto?>(topic);
		}

		public async Task<IEnumerable<TopicReturnDto>> GetTopics(Guid chapterId, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var topics = await repositoryManager.Topics.GetTopics(chapterId, trackChange);
			return mapper.Map<IEnumerable<TopicReturnDto>>(topics);
		}

		public async Task UpdateTopic(Guid chapterId, Guid id, TopicForUpdateDto topicForUpdate, bool chapterTrackChange, bool topicTrackChange)
		{
			await CheckChapterExist(chapterId, chapterTrackChange);

			var topic = await repositoryManager.Topics.GetTopic(chapterId, id, topicTrackChange);
			if (topic == null) throw new TopicNotFoundException(id);

			mapper.Map(topicForUpdate, topic);
			topic.UpdatedAt = DateTime.Now;
			await repositoryManager.Save();
		}
	}
}
