using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

namespace Mindmath.Infrastructure.Repository
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly MindmathDbContext _context;
		private readonly Lazy<ISubjectRepository> _subjectRepository;
		private readonly Lazy<IChapterRepository> _chapterRepository;
		private readonly Lazy<ITopicRepository> _topicRepository;
		private readonly Lazy<IProblemTypeRepository> _problemTypeRepository;
		public RepositoryManager(MindmathDbContext context)
		{
			_context = context;
			_subjectRepository = new Lazy<ISubjectRepository>(() => new SubjectRepository(_context));
			_chapterRepository = new Lazy<IChapterRepository>(() => new ChapterRepository(_context));
			_topicRepository = new Lazy<ITopicRepository>(() => new TopicRepository(_context));
			_problemTypeRepository = new Lazy<IProblemTypeRepository>(() => new ProblemTypeRepository(_context));
		}

		public ISubjectRepository Subjects => _subjectRepository.Value;

		public IChapterRepository Chapters => _chapterRepository.Value;

		public ITopicRepository Topics => _topicRepository.Value;

		public IProblemTypeRepository ProblemTypes => _problemTypeRepository.Value;

		public async Task Save() => await _context.SaveChangesAsync();
	}
}
