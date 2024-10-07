using Mindmath.Service.Transactions.DTO;

namespace Mindmath.Service.Transactions
{
	public interface ITransactionService
	{
		Task<IEnumerable<TransactionReturnDto>> GetTransactions(bool trackChange);
		Task<IEnumerable<TransactionReturnDto>> GetTransactionsByUserId(string userId, bool trackChange);

	}
}
