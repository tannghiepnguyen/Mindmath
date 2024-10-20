using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;

namespace Mindmath.Repository.IRepository
{
	public interface IChapterRepository
	{
		Task<PagedList<Chapter>> GetChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange);
		Task<PagedList<Chapter>> GetActiveChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange);
		Task<Chapter?> GetChapter(Guid subjectId, Guid id, bool trackChange);
		Task<Chapter?> GetChapter(Guid id, bool trackChange);
		void CreateChapter(Chapter chapter);
	}
}
