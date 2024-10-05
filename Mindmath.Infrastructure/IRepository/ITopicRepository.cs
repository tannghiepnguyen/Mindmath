using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface ITopicRepository
	{
		Task<IEnumerable<Topic>> GetTopics(Guid chapterId, bool trackChange);
		Task<IEnumerable<Topic>> GetActiveTopics(Guid chapterId, bool trackChange);
		Task<Topic?> GetTopic(Guid chapterId, Guid id, bool trackChange);
		Task<Topic?> GetTopic(Guid id, bool trackChange);
		void CreateTopic(Topic topic);

	}
}
