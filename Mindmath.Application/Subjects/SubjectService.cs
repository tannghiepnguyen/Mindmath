using AutoMapper;
using Mindmath.Application.Subjects.DTO;
using Mindmath.Domain.Exceptions;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;

namespace Mindmath.Application.Subjects
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
			repositoryManager.Subjects.DeleteSubject(subjectEntity);
			await repositoryManager.Save();
		}

		public async Task<IEnumerable<SubjectReturnDto>> GetActiveSubjects(bool trackChange)
		{
			var activeSubjects = await repositoryManager.Subjects.GetActiveSubjects(trackChange);
			return mapper.Map<IEnumerable<SubjectReturnDto>>(activeSubjects);
		}

		public async Task<SubjectReturnDto?> GetSubject(Guid id, bool trackChange)
		{
			var subject = await repositoryManager.Subjects.GetSubject(id, trackChange);
			if (subject == null) throw new SubjectNotFoundException(id);
			return mapper.Map<SubjectReturnDto?>(subject);
		}

		public async Task<IEnumerable<SubjectReturnDto>> GetSubjects(bool trackChange)
		{
			var subjects = await repositoryManager.Subjects.GetSubjects(trackChange);
			await repositoryManager.Save();
			return mapper.Map<IEnumerable<SubjectReturnDto>>(subjects);
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
