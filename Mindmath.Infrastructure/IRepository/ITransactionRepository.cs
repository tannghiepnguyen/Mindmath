using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface ITransactionRepository
	{
		void CreateTransaction(Transaction transaction);
		Task<IEnumerable<Transaction>> GetTransactions(bool trackChange);
		Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId, bool trackChange);
	}
}
