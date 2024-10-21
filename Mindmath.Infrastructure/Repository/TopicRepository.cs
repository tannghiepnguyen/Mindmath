using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class TopicRepository : RepositoryBase<Topic>, ITopicRepository
	{
		public TopicRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateTopic(Topic topic) => Create(topic);

		public async Task<PagedList<Topic>> GetActiveTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange)
		{
			var topics = FindByCondition(x => x.ChapterId == chapterId && x.Active, trackChange);
			if (!string.IsNullOrEmpty(topicParameters.SearchTerm))
			{
				var lowerCaseTerm = topicParameters.SearchTerm.Trim().ToLower();
				topics = topics.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
			}
			topics = topics.OrderBy(c => c.Name);
			return PagedList<Topic>.ToPagedList(topics, topicParameters.PageNumber, topicParameters.PageSize);
		}

		public async Task<Topic?> GetTopic(Guid chapterId, Guid id, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId && x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<Topic?> GetTopic(Guid id, bool trackChange) => await FindByCondition(x => x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<Topic>> GetTopics(Guid chapterId, TopicParameters topicParameters, bool trackChange)
		{
			var topics = FindByCondition(x => x.ChapterId == chapterId, trackChange);
			if (!string.IsNullOrEmpty(topicParameters.SearchTerm))
			{
				var lowerCaseTerm = topicParameters.SearchTerm.Trim().ToLower();
				topics = topics.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
			}
			topics = topics.OrderBy(c => c.Name);
			return PagedList<Topic>.ToPagedList(topics, topicParameters.PageNumber, topicParameters.PageSize);
		}
	}
}
