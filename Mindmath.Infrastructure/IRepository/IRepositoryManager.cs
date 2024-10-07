namespace Mindmath.Repository.IRepository
{
	public interface IRepositoryManager
	{
		ISubjectRepository Subjects { get; }
		IChapterRepository Chapters { get; }
		ITopicRepository Topics { get; }
		IProblemTypeRepository ProblemTypes { get; }
		IWalletRepository Wallets { get; }
		IInputParameterRepository InputParameters { get; }
		ISolutionRepository Solutions { get; }
		ITransactionRepository Transactions { get; }
		Task Save();
	}
}
