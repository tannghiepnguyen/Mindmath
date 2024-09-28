using Mindmath.Application.Subjects.DTO;

namespace Mindmath.Application.Subjects
{
	public interface ISubjectService
	{
		Task<IEnumerable<SubjectReturnDto>> GetSubjects(bool trackChange);
		Task<IEnumerable<SubjectReturnDto>> GetActiveSubjects(bool trackChange);
		Task<SubjectReturnDto?> GetSubject(Guid id, bool trackChange);
		Task<SubjectReturnDto> CreateSubject(SubjectForCreationDto subject);
		Task UpdateSubject(Guid id, SubjectForUpdateDto subjectForUpdate, bool trackChange);
	}
}
