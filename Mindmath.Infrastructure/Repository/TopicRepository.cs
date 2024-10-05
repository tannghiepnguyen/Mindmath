using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
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

		public async Task<IEnumerable<Topic>> GetActiveTopics(Guid chapterId, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId && x.Active, trackChange).ToListAsync();

		public async Task<Topic?> GetTopic(Guid chapterId, Guid id, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId && x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<Topic?> GetTopic(Guid id, bool trackChange) => await FindByCondition(x => x.Id == id, trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<Topic>> GetTopics(Guid chapterId, bool trackChange) => await FindByCondition(x => x.ChapterId == chapterId, trackChange).ToListAsync();
	}
}
