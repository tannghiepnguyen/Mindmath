using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface ISubjectRepository
	{
		Task<IEnumerable<Subject>> GetSubjects(bool trackChange);
		Task<IEnumerable<Subject>> GetActiveSubjects(bool trackChange);
		Task<Subject?> GetSubject(Guid id, bool trackChange);
		void CreateSubject(Subject subject);
		void DeleteSubject(Subject subject);
	}
}
