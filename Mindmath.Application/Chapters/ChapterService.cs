using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
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

		public async Task<IEnumerable<ChapterReturnDto>> GetActiveChapters(Guid subjectId, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var activeChapters = await repositoryManager.Chapters.GetActiveChapters(subjectId, trackChange);
			return mapper.Map<IEnumerable<ChapterReturnDto>>(activeChapters);
		}

		public async Task<ChapterReturnDto?> GetChapter(Guid subjectId, Guid id, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var chapter = await repositoryManager.Chapters.GetChapter(subjectId, id, trackChange);
			if (chapter == null) throw new ChapterNotFoundException(id);

			return mapper.Map<ChapterReturnDto?>(chapter);
		}

		public async Task<IEnumerable<ChapterReturnDto>> GetChapters(Guid subjectId, bool trackChange)
		{
			await CheckSubjectExist(subjectId, trackChange);

			var chapters = await repositoryManager.Chapters.GetChapters(subjectId, trackChange);
			return mapper.Map<IEnumerable<ChapterReturnDto>>(chapters);
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
	}
}
