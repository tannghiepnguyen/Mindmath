using AutoMapper;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Subjects.DTO;

namespace Mindmath.Service.Subjects
{
	internal sealed class SubjectService : ISubjectService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public SubjectService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}
		public async Task<SubjectReturnDto> CreateSubject(SubjectForCreationDto subjectCreateDto)
		{
			var subjectEntity = mapper.Map<Subject>(subjectCreateDto);
			subjectEntity.Id = Guid.NewGuid();
			subjectEntity.CreatedAt = DateTime.Now;
			subjectEntity.UpdatedAt = DateTime.Now;
			subjectEntity.Active = true;
			repositoryManager.Subjects.CreateSubject(subjectEntity);
			await repositoryManager.Save();
			return mapper.Map<SubjectReturnDto>(subjectEntity);
		}

		public async Task DeleteSubject(Guid id, bool trackChange)
		{
			var subjectEntity = await repositoryManager.Subjects.GetSubject(id, trackChange);
			if (subjectEntity is null) throw new SubjectNotFoundException(id);
			subjectEntity.Active = false;
			subjectEntity.DeletedAt = DateTime.Now;
			await repositoryManager.Save();
		}

		public async Task<(IEnumerable<SubjectReturnDto> subjects, MetaData metaData)> GetActiveSubjects(SubjectParameters subjectParameters, bool trackChange)
		{
			var activeSubjectsWithMetaData = await repositoryManager.Subjects.GetActiveSubjects(subjectParameters, trackChange);
			var activeSubjects = mapper.Map<IEnumerable<SubjectReturnDto>>(activeSubjectsWithMetaData);
			return (activeSubjects, activeSubjectsWithMetaData.MetaData);
		}

		public async Task<SubjectReturnDto?> GetSubject(Guid id, bool trackChange)
		{
			var subject = await repositoryManager.Subjects.GetSubject(id, trackChange);
			if (subject == null) throw new SubjectNotFoundException(id);
			return mapper.Map<SubjectReturnDto?>(subject);
		}

		public async Task<(IEnumerable<SubjectReturnDto> subjects, MetaData metaData)> GetSubjects(SubjectParameters subjectParameters, bool trackChange)
		{
			var subjectsWithMetaData = await repositoryManager.Subjects.GetSubjects(subjectParameters, trackChange);
			var subjects = mapper.Map<IEnumerable<SubjectReturnDto>>(subjectsWithMetaData);
			return (subjects, subjectsWithMetaData.MetaData);
		}

		public async Task UpdateSubject(Guid id, SubjectForUpdateDto subjectForUpdate, bool trackChange)
		{
			var subjectEntity = await repositoryManager.Subjects.GetSubject(id, trackChange);
			if (subjectEntity is null) throw new SubjectNotFoundException(id);
			mapper.Map(subjectForUpdate, subjectEntity);
			subjectEntity.UpdatedAt = DateTime.Now;
			await repositoryManager.Save();
		}
	}
}
