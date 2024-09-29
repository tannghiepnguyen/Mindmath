using Microsoft.EntityFrameworkCore;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class TopicRepository : RepositoryBase<Topic>, ITopicRepository
	{
		public TopicRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateTopic(Guid chapterId, Topic topic)
		{
			topic.ChapterId = chapterId;
			Create(topic);
		}

		public async Task<IEnumerable<Topic>> GetActiveTopics(Guid chapterId, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId && x.Active, trackChange).ToListAsync();

		public async Task<Topic?> GetTopic(Guid chapterId, Guid id, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId && x.Id == id, trackChange).SingleOrDefaultAsync();

		public Task<Topic?> GetTopic(Guid id, bool trackChange) => FindByCondition(x => x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<Topic>> GetTopics(Guid chapterId, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId, trackChange).ToListAsync();
	}
}
