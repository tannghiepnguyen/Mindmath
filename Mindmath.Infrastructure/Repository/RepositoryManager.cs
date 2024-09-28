using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

namespace Mindmath.Infrastructure.Repository
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly MindmathDbContext _context;
		private readonly Lazy<ISubjectRepository> _subjectRepository;
		public RepositoryManager(MindmathDbContext context)
		{
			_context = context;
			_subjectRepository = new Lazy<ISubjectRepository>(() => new SubjectRepository(_context));
		}

		public ISubjectRepository Subjects => _subjectRepository.Value;

		public async Task Save() => await _context.SaveChangesAsync();
	}
}
