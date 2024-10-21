using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Transactions.DTO;

namespace Mindmath.Service.Transactions
{
	public interface ITransactionService
	{
		Task<(IEnumerable<TransactionReturnDto> transactions, MetaData metaData)> GetTransactions(TransactionParameters transactionParameters, bool trackChange);
		Task<(IEnumerable<TransactionReturnDto> transactions, MetaData metaData)> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange);

	}
}
