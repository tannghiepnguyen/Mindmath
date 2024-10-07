using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.Persistence;

namespace Mindmath.Repository.Repository
{
	public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
	{
		public TransactionRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateTransaction(Transaction transaction) => Create(transaction);

		public async Task<IEnumerable<Transaction>> GetTransactions(bool trackChange) => await FindAll(trackChange).Include(c => c.User).AsSplitQuery().ToListAsync();

		public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId, bool trackChange) => await FindByCondition(x => x.UserId == userId, trackChange).Include(c => c.User).AsSplitQuery().ToListAsync();
	}
}
