using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Topics.DTO;

namespace Mindmath.Service.Topics
{
	public interface ITopicService
	{
		Task<(IEnumerable<TopicReturnDto> topics, MetaData metaData)> GetTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange);
		Task<(IEnumerable<TopicReturnDto> topics, MetaData metaData)> GetActiveTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange);
		Task<TopicReturnDto?> GetTopic(Guid chapterId, Guid id, bool trackChange);
		Task<TopicReturnDto> CreateTopic(Guid chapterId, TopicForCreationDto topic, bool trackChange);
		Task UpdateTopic(Guid chapterId, Guid id, TopicForUpdateDto topicForUpdate, bool chapterTrackChange, bool topicTrackChange);
		Task DeleteTopic(Guid chapterId, Guid id, bool chapterTrackChange, bool topicTrackChange);
	}
}
