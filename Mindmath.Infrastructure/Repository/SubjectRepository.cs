using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
	{
		public SubjectRepository(MindmathDbContext context) : base(context) { }
		public void CreateSubject(Subject subject) => Create(subject);

		public async Task<PagedList<Subject>> GetActiveSubjects(SubjectParameters subjectParameters, bool trackChange)
		{
			var subjects = FindByCondition(s => s.Active, trackChange).OrderBy(c => c.Name);
			return PagedList<Subject>.ToPagedList(subjects, subjectParameters.PageNumber, subjectParameters.PageSize);
		}

		public async Task<Subject?> GetSubject(Guid id, bool trackChange) => await FindByCondition(s => s.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<Subject>> GetSubjects(SubjectParameters subjectParameters, bool trackChange)
		{
			var subjects = FindAll(trackChange).OrderBy(c => c.Name);
			return PagedList<Subject>.ToPagedList(subjects, subjectParameters.PageNumber, subjectParameters.PageSize);
		}

		public void DeleteSubject(Subject subject) => Delete(subject);
	}
}
