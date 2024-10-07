using Mindmath.Service.Chapters;
using Mindmath.Service.InputParameters;
using Mindmath.Service.ProblemTypes;
using Mindmath.Service.Solutions;
using Mindmath.Service.Subjects;
using Mindmath.Service.Topics;
using Mindmath.Service.Transactions;
using Mindmath.Service.Users;
using Mindmath.Service.Wallets;

namespace Mindmath.Service.IService
{
	public interface IServiceManager
	{
		ISubjectService SubjectService { get; }
		IChapterService ChapterService { get; }
		IAuthenticationService AuthenticationService { get; }
		ITopicService TopicService { get; }
		IProblemTypeService ProblemTypeService { get; }
		IInputParameterService InputParameterService { get; }
		ITransactionService TransactionService { get; }
		ISolutionService SolutionService { get; }
		IWalletService WalletService { get; }
	}
}
