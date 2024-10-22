using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Chapters.DTO;


namespace Mindmath.Service.Chapters
{
	internal sealed class ChapterService : IChapterService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public ChapterService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}

		private async Task CheckSubjectExist(Guid subjectId, bool trackChange)
		{
			var subject = await repositoryManager.Subjects.GetSubject(subjectId, trackChange);
			if (subject == null) throw new SubjectNotFoundException(subjectId);
		}

		public async Task<ChapterReturnDto> CreateChapter(Guid subjectId, ChapterForCreationDto chapterForCreation, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var chapterEntity = mapper.Map<Chapter>(chapterForCreation);
			chapterEntity.Id = Guid.NewGuid();
			chapterEntity.CreatedAt = DateTime.Now;
			chapterEntity.UpdatedAt = DateTime.Now;
			chapterEntity.Active = true;
			chapterEntity.SubjectId = subjectId;
			repositoryManager.Chapters.CreateChapter(chapterEntity);
			await repositoryManager.Save();
			return mapper.Map<ChapterReturnDto>(chapterEntity);
		}

		public async Task<(IEnumerable<ChapterReturnDto> chapters, MetaData metaData)> GetActiveChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var activeChaptersWithMetaData = await repositoryManager.Chapters.GetActiveChapters(subjectId, chapterParameters, trackChange);
			var activeChapters = mapper.Map<IEnumerable<ChapterReturnDto>>(activeChaptersWithMetaData);
			return (activeChapters, activeChaptersWithMetaData.MetaData);
		}

		public async Task<ChapterReturnDto?> GetChapter(Guid subjectId, Guid id, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var chapter = await repositoryManager.Chapters.GetChapter(subjectId, id, trackChange);
			if (chapter == null) throw new ChapterNotFoundException(id);

			return mapper.Map<ChapterReturnDto?>(chapter);
		}

		public async Task<(IEnumerable<ChapterReturnDto> chapters, MetaData metaData)> GetChapters(Guid subjectId, ChapterParameters chapterParameters, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var chaptersWithMetaData = await repositoryManager.Chapters.GetChapters(subjectId, chapterParameters, trackChange);
			var chapters = mapper.Map<IEnumerable<ChapterReturnDto>>(chaptersWithMetaData);
			return (chapters, chaptersWithMetaData.MetaData);
		}

		public async Task UpdateChapter(Guid subjectId, Guid id, ChapterForUpdateDto chapterForUpdate, bool chapterTrackChange, bool subjectTrackChange)
		{
			await CheckSubjectExist(subjectId, subjectTrackChange);

			var chapterEntity = await repositoryManager.Chapters.GetChapter(subjectId, id, chapterTrackChange);
			if (chapterEntity == null) throw new ChapterNotFoundException(id);

			mapper.Map(chapterForUpdate, chapterEntity);
			chapterEntity.UpdatedAt = DateTime.Now;
			await repositoryManager.Save();

		}

		public async Task DeleteChapter(Guid subjectId, Guid id, bool chapterTrackChange, bool subjectTrackChange)
		{
			await CheckSubjectExist(subjectId, subjectTrackChange);

			var chapterEntity = await repositoryManager.Chapters.GetChapter(subjectId, id, chapterTrackChange);
			if (chapterEntity == null) throw new ChapterNotFoundException(id);

			chapterEntity.Active = false;
			chapterEntity.DeletedAt = DateTime.Now;
			await repositoryManager.Save();
		}
	}
}
