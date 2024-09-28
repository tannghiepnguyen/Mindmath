using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

namespace Mindmath.Infrastructure.Repository
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly MindmathDbContext _context;
		private readonly Lazy<ISubjectRepository> _subjectRepository;
		private readonly Lazy<IChapterRepository> _chapterRepository;
		public RepositoryManager(MindmathDbContext context)
		{
			_context = context;
			_subjectRepository = new Lazy<ISubjectRepository>(() => new SubjectRepository(_context));
			_chapterRepository = new Lazy<IChapterRepository>(() => new ChapterRepository(_context));
		}

		public ISubjectRepository Subjects => _subjectRepository.Value;

		public IChapterRepository Chapters => _chapterRepository.Value;

		public async Task Save() => await _context.SaveChangesAsync();
	}
}
