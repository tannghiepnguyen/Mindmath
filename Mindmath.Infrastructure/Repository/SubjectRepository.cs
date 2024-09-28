using Microsoft.EntityFrameworkCore;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

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
