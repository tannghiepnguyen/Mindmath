using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
	{
		public SubjectRepository(MindmathDbContext context) : base(context) { }
		public void CreateSubject(Subject subject) => Create(subject);

		public async Task<IEnumerable<Subject>> GetActiveSubjects(bool trackChange) => await FindByCondition(s => s.Active, trackChange).ToListAsync();

		public async Task<Subject?> GetSubject(Guid id, bool trackChange) => await FindByCondition(s => s.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<Subject>> GetSubjects(bool trackChange) => await FindAll(trackChange).ToListAsync();

		public void DeleteSubject(Subject subject) => Delete(subject);
	}
}
