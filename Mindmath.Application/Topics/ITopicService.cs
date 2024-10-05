using Mindmath.Service.Topics.DTO;

namespace Mindmath.Service.Topics
{
	public interface ITopicService
	{
		Task<IEnumerable<TopicReturnDto>> GetTopics(Guid chapterId, bool trackChange);
		Task<IEnumerable<TopicReturnDto>> GetActiveTopics(Guid chapterId, bool trackChange);
		Task<TopicReturnDto?> GetTopic(Guid chapterId, Guid id, bool trackChange);
		Task<TopicReturnDto> CreateTopic(Guid chapterId, TopicForCreationDto topic, bool trackChange);
		Task UpdateTopic(Guid chapterId, Guid id, TopicForUpdateDto topicForUpdate, bool chapterTrackChange, bool topicTrackChange);
	}
}
