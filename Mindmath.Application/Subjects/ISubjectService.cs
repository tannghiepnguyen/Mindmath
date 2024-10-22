using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Subjects.DTO;

namespace Mindmath.Service.Subjects
{
	public interface ISubjectService
	{
		Task<(IEnumerable<SubjectReturnDto> subjects, MetaData metaData)> GetSubjects(SubjectParameters subjectParameters, bool trackChange);
		Task<(IEnumerable<SubjectReturnDto> subjects, MetaData metaData)> GetActiveSubjects(SubjectParameters subjectParameters, bool trackChange);
		Task<SubjectReturnDto?> GetSubject(Guid id, bool trackChange);
		Task<SubjectReturnDto> CreateSubject(SubjectForCreationDto subject);
		Task UpdateSubject(Guid id, SubjectForUpdateDto subjectForUpdate, bool trackChange);
		Task DeleteSubject(Guid id, bool trackChange);
	}
}
