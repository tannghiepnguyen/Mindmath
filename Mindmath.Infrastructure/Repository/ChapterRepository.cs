using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Repository.Persistence;

namespace Mindmath.Repository.Repository
{
	internal sealed class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
	{
		public ChapterRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateChapter(Chapter chapter) => Create(chapter);

		public async Task<PagedList<Chapter>> GetActiveChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange)
		{
			var chapters = FindByCondition(c => c.SubjectId.Equals(subjectId) && c.Active, trackChange).OrderBy(c => c.Name);
			return PagedList<Chapter>.ToPagedList(chapters, chapterParameters.PageNumber, chapterParameters.PageSize);

		}
		public async Task<Chapter?> GetChapter(Guid subjectId, Guid id, bool trackChange) => await FindByCondition(c => c.SubjectId.Equals(subjectId) && c.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<Chapter?> GetChapter(Guid id, bool trackChange) => await FindByCondition(c => c.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<Chapter>> GetChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange)
		{
			var chapters = FindByCondition(c => c.SubjectId.Equals(subjectId), trackChange).OrderBy(c => c.Name);
			return PagedList<Chapter>.ToPagedList(chapters, chapterParameters.PageNumber, chapterParameters.PageSize);
		}
	}
}
