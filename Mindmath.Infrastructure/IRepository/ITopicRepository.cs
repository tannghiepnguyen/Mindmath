using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;

namespace Mindmath.Repository.IRepository
{
	public interface ITopicRepository
	{
		Task<PagedList<Topic>> GetTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange);
		Task<PagedList<Topic>> GetActiveTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange);
		Task<Topic?> GetTopic(Guid chapterId, Guid id, bool trackChange);
		Task<Topic?> GetTopic(Guid id, bool trackChange);
		void CreateTopic(Topic topic);

	}
}
