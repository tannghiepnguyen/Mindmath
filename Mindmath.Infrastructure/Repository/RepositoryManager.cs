using Mindmath.Repository.IRepository;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly MindmathDbContext _context;
		private readonly Lazy<ISubjectRepository> _subjectRepository;
		private readonly Lazy<IChapterRepository> _chapterRepository;
		private readonly Lazy<ITopicRepository> _topicRepository;
		private readonly Lazy<IProblemTypeRepository> _problemTypeRepository;
		private readonly Lazy<IWalletRepository> _walletRepository;
		private readonly Lazy<IInputParameterRepository> _inputParameterRepository;
		private readonly Lazy<ISolutionRepository> _solutionRepository;
		private readonly Lazy<ITransactionRepository> _transactionRepository;
		public RepositoryManager(MindmathDbContext context)
		{
			_context = context;
			_subjectRepository = new Lazy<ISubjectRepository>(() => new SubjectRepository(_context));
			_chapterRepository = new Lazy<IChapterRepository>(() => new ChapterRepository(_context));
			_topicRepository = new Lazy<ITopicRepository>(() => new TopicRepository(_context));
			_problemTypeRepository = new Lazy<IProblemTypeRepository>(() => new ProblemTypeRepository(_context));
			_walletRepository = new Lazy<IWalletRepository>(() => new WalletRepository(_context));
			_inputParameterRepository = new Lazy<IInputParameterRepository>(() => new InputParameterRepository(_context));
			_solutionRepository = new Lazy<ISolutionRepository>(() => new SolutionRepository(_context));
			_transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(_context));
		}

		public ISubjectRepository Subjects => _subjectRepository.Value;

		public IChapterRepository Chapters => _chapterRepository.Value;

		public ITopicRepository Topics => _topicRepository.Value;

		public IProblemTypeRepository ProblemTypes => _problemTypeRepository.Value;

		public IWalletRepository Wallets => _walletRepository.Value;

		public IInputParameterRepository InputParameters => _inputParameterRepository.Value;

		public ISolutionRepository Solutions => _solutionRepository.Value;

		public ITransactionRepository Transactions => _transactionRepository.Value;

		public async Task Save() => await _context.SaveChangesAsync();
	}
}
