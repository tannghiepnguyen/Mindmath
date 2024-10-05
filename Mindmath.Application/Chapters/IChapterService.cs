using Mindmath.Service.Chapters.DTO;

namespace Mindmath.Service.Chapters
{
	public interface IChapterService
	{
		Task<IEnumerable<ChapterReturnDto>> GetChapters(Guid subjectId, bool trackChange);
		Task<IEnumerable<ChapterReturnDto>> GetActiveChapters(Guid subjectId, bool trackChange);
		Task<ChapterReturnDto?> GetChapter(Guid subjectId, Guid id, bool trackChange);
		Task<ChapterReturnDto> CreateChapter(Guid subjectId, ChapterForCreationDto chapter, bool trackChange);
		Task UpdateChapter(Guid subjectId, Guid id, ChapterForUpdateDto chapterForUpdate, bool chapterTrackChange, bool subjectTrackChange);
	}
}
