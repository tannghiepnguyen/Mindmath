using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
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

		public async Task<(IEnumerable<TopicReturnDto> topics, MetaData metaData)> GetActiveTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var activeTopicsMetaData = await repositoryManager.Topics.GetActiveTopics(chapterId, topicParameters, trackChange);
			var activeTopics = mapper.Map<IEnumerable<TopicReturnDto>>(activeTopicsMetaData);
			return (activeTopics, activeTopicsMetaData.MetaData);
		}

		public async Task<TopicReturnDto?> GetTopic(Guid chapterId, Guid id, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var topic = await repositoryManager.Topics.GetTopic(chapterId, id, trackChange);
			if (topic == null) throw new TopicNotFoundException(id);

			return mapper.Map<TopicReturnDto?>(topic);
		}

		public async Task<(IEnumerable<TopicReturnDto> topics, MetaData metaData)> GetTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange)
		{
			await CheckChapterExist(chapterId, trackChange);

			var topicsMetaData = await repositoryManager.Topics.GetTopics(chapterId, topicParameters, trackChange);
			var topics = mapper.Map<IEnumerable<TopicReturnDto>>(topicsMetaData);
			return (topics, topicsMetaData.MetaData);
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

		public async Task DeleteTopic(Guid chapterId, Guid id, bool chapterTrackChange, bool topicTrackChange)
		{
			await CheckChapterExist(chapterId, chapterTrackChange);

			var topic = await repositoryManager.Topics.GetTopic(chapterId, id, topicTrackChange);
			if (topic == null) throw new TopicNotFoundException(id);

			topic.Active = false;
			topic.DeletedAt = DateTime.Now;
			await repositoryManager.Save();
		}
	}
}
