using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Chapters.DTO;

namespace Mindmath.Service.Chapters
{
	public interface IChapterService
	{
		Task<(IEnumerable<ChapterReturnDto> chapters, MetaData metaData)> GetChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange);
		Task<(IEnumerable<ChapterReturnDto> chapters, MetaData metaData)> GetActiveChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange);
		Task<ChapterReturnDto?> GetChapter(Guid subjectId, Guid id, bool trackChange);
		Task<ChapterReturnDto> CreateChapter(Guid subjectId, ChapterForCreationDto chapter, bool trackChange);
		Task UpdateChapter(Guid subjectId, Guid id, ChapterForUpdateDto chapterForUpdate, bool chapterTrackChange, bool subjectTrackChange);
	}
}
