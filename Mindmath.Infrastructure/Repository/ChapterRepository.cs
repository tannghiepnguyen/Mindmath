using Microsoft.EntityFrameworkCore;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
	{
		public ChapterRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateChapter(Guid subjectId, Chapter chapter)
		{
			chapter.SubjectId = subjectId;
			Create(chapter);
		}

		public async Task<IEnumerable<Chapter>> GetActiveChapters(Guid subjectId, bool trackChange) => await FindByCondition(c => c.SubjectId.Equals(subjectId) && c.Active, trackChange).ToListAsync();

		public async Task<Chapter?> GetChapter(Guid subjectId, Guid id, bool trackChange) => await FindByCondition(c => c.SubjectId.Equals(subjectId) && c.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<Chapter?> GetChapter(Guid id, bool trackChange) => await FindByCondition(c => c.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<Chapter>> GetChapters(Guid subjectId, bool trackChange) => await FindByCondition(c => c.SubjectId.Equals(subjectId), trackChange).ToListAsync();
	}
}
