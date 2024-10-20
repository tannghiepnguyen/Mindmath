using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;

namespace Mindmath.Repository.IRepository
{
	public interface ISubjectRepository
	{
		Task<PagedList<Subject>> GetSubjects(SubjectParameters subjectParameters, bool trackChange);
		Task<PagedList<Subject>> GetActiveSubjects(SubjectParameters subjectParameters, bool trackChange);
		Task<Subject?> GetSubject(Guid id, bool trackChange);
		void CreateSubject(Subject subject);
		void DeleteSubject(Subject subject);
	}
}
