using Mindmath.Domain.Models;

namespace Mindmath.Domain.Repository
{
	public interface IChapterRepository
	{
		Task<IEnumerable<Chapter>> GetChapters(Guid subjectId, bool trackChange);
		Task<IEnumerable<Chapter>> GetActiveChapters(Guid subjectId, bool trackChange);
		Task<Chapter?> GetChapter(Guid subjectId, Guid id, bool trackChange);
		Task<Chapter?> GetChapter(Guid id, bool trackChange);
		void CreateChapter(Guid subjectId, Chapter chapter);
	}
}
