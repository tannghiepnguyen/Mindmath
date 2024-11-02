using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;

namespace Mindmath.Repository.IRepository
{
	public interface ITransactionRepository
	{
		void CreateTransaction(Transaction transaction);
		Task<Transaction> AddTransactionAsync(Transaction transaction);
		Task<Transaction?> GetTransactionByIdAsync(Guid id);
		Task<Transaction?> GetTransactionById(Guid id, bool trackChange);
		Task<PagedList<Transaction>> GetTransactions(TransactionParameters transactionParameters, bool trackChange);
		Task<PagedList<Transaction>> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange);
	}
}
